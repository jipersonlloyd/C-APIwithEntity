using C_BackendEntity.Model;
using System.Linq.Expressions;

namespace C_BackendEntity.Repository.Interface
{
    public interface IAccountRepository
    {
        Task<AccountModel> IsAccountExist(Expression<Func<AccountModel, bool>> predicate);
        void AddModel(AccountModel createAccountModel);

        void UpdateModel(AccountModel accountModel);

        Task<AccountModel> GetRefreshToken(string token);
    }
}
