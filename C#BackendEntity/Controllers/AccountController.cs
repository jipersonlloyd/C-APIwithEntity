using C_BackendEntity.Model;
using C_BackendEntity.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using System.Security.Claims;

namespace C_BackendEntity.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AccountController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService, ITokenService tokenService) 
        {
            _accountService = accountService;
            _tokenService = tokenService;
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> IsAccountExist([FromBody]LoginModel loginModel)
        {
            AccountModel accountModel = await _accountService.IsAccountExist(loginModel.Email);

            if (accountModel == null) return Ok(new
            {
                status = false,
                message = "Account doesn't exist"
            });

            if (accountModel.Email != loginModel.Email || accountModel.Password != loginModel.Password) return Ok(new
            {
                status = false,
                message = "Incorrect Username or Password"
            });


            var claims = new List<Claim> 
            {
                new Claim(ClaimTypes.Name, accountModel.Email),
                new Claim(ClaimTypes.NameIdentifier, accountModel.Id.ToString())
            };
            var accessToken = _tokenService.GenerateAccessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();

            accountModel.RefreshToken = refreshToken;
            accountModel.RefreshTokenExpiryTime = _tokenService.SetRefreshTokenTime();

            _accountService.UpdateModel(accountModel);


            return Ok(new
            {
                status = true,
                message = "Account Login Successfully",
                AccessToken = accessToken,
                RefreshToken = refreshToken, 
            });
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken(string token)
        {
            AccountModel accountModel = await _accountService.GetRefreshToken(token);
            if (accountModel == null || accountModel.RefreshTokenExpiryTime <= DateTime.Now) 
            {
                return Unauthorized();
            }

            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, accountModel.Email),
            new Claim(ClaimTypes.NameIdentifier, accountModel.Id.ToString())
        };

            var accessToken = _tokenService.GenerateAccessToken(claims);

            return Ok(new
            {
                status = true,
                AccessToken = accessToken,
            });
        } 


        [Route("createaccount")]
        [HttpPost]
        public IActionResult AddModel([FromBody] AccountModel accountModel) 
        {
            Dictionary<string, dynamic> result;
            try 
            {
                _accountService.AddModel(accountModel);
                result = new Dictionary<string, dynamic>
                {
                    {"status", true},
                    {"message", "Account Created Successfully"}
                };

                return Ok(result);
            }
            catch (Exception e) 
            {
                result = new Dictionary<string, dynamic>
                {
                    {"status", false},
                    {"message", $"{e}"}
                };

                return Ok(result);
            }
        }
    }
}
