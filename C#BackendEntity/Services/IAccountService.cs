using C_BackendEntity.Model;

namespace C_BackendEntity.Services
{
    public interface IAccountService
    {
        Task<AccountModel> IsAccountExist(string email);
        void AddModel(AccountModel createAccountModel);
    }
}
