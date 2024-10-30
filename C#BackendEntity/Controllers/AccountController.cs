using C_BackendEntity.Model;
using C_BackendEntity.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace C_BackendEntity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService) 
        {
            _accountService = accountService;
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> IsAccountExist([FromBody]LoginModel loginModel)
        {
            Dictionary<string, dynamic> result;
            AccountModel accountModel = await _accountService.IsAccountExist(loginModel.Email);

            if (accountModel == null)
            {
                result = new Dictionary<string, dynamic>
                {
                    {"status", false},
                    {"message", "Email doesn't exist"}
                };
                return Ok(result);
            };

            if (accountModel.Password != loginModel.Password)
            {
                result = new Dictionary<string, dynamic>
                {
                    {"status", false},
                    {"message", "Incorrect Password"}
                };
                return Ok(result);
            }

            result = new Dictionary<string, dynamic>
                {
                    {"status", true},
                    {"message", "Account Login Successfully"}
                };

            return Ok(result);
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
