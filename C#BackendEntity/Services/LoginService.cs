using C_BackendEntity.Model;
using C_BackendEntity.Repository;

namespace C_BackendEntity.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository<LoginModel> _loginRepository;
        public LoginService(ILoginRepository<LoginModel> loginRepository) 
        {
            _loginRepository = loginRepository;
        }


        public async Task<LoginModel> IsAccountExist(string email) => await _loginRepository.IsAccountExist(u => u.Email == email);

    }
}
