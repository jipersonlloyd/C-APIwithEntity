using C_BackendEntity.Model;
using C_BackendEntity.Repository.Interface;
using C_BackendEntity.Services.Interface;

namespace C_BackendEntity.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _loginRepository;
        public AccountService(IAccountRepository loginRepository) 
        {
            _loginRepository = loginRepository;
        }


        public async Task<AccountModel> IsAccountExist(string email) => await _loginRepository.IsAccountExist(email);
        public void AddModel(AccountModel createAccountModel) => _loginRepository.AddModel(createAccountModel);

        public void UpdateModel(AccountModel accountModel) => _loginRepository.UpdateModel(accountModel);

        public async Task<AccountModel> GetRefreshToken(string token) => await _loginRepository.GetRefreshToken(token); 

    }
}
