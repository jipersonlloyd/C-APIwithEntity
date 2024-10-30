using C_BackendEntity.Data;
using C_BackendEntity.Model;
using C_BackendEntity.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace C_BackendEntity.Services
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext _appDbContext;
        public AccountRepository(AppDbContext appDbContext) 
        {
            _appDbContext = appDbContext;
        }

        public async Task<AccountModel> IsAccountExist(Expression<Func<AccountModel, bool>> predicate) => await _appDbContext.Set<AccountModel>().FirstOrDefaultAsync(predicate);
        public void AddModel(AccountModel entity) 
        {
            _appDbContext.Add(entity);
            _appDbContext.SaveChanges();
        }

    }
}
