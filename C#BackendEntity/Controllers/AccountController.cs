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
        private readonly ILoginService _loginService;
        public AccountController(ILoginService loginService) 
        {
            _loginService = loginService;
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> IsAccountExist([FromBody]LoginModel loginModel)
        {
            Dictionary<string, dynamic> result;
            LoginModel _loginModel = await _loginService.IsAccountExist(loginModel.Email);

            if (_loginModel == null)
            {
                result = new Dictionary<string, dynamic>
                {
                    {"status", false},
                    {"message", "Email doesn't exist"}
                };
                return Ok(result);
            };

            if (_loginModel.Password != loginModel.Password)
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
    }
}
