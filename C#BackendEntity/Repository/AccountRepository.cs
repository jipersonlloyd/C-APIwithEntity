using C_BackendEntity.Data;
using C_BackendEntity.Model;
using C_BackendEntity.Repository.Interface;
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

        public async Task<AccountModel> IsAccountExist(string email) => await _appDbContext.Set<AccountModel>().FirstOrDefaultAsync(x => x.Email == email);
        public void AddModel(AccountModel entity) 
        {
            _appDbContext.Add(entity);
            _appDbContext.SaveChanges();
        }

        public void UpdateModel(AccountModel entity) 
        {
            _appDbContext.Update(entity);
            _appDbContext.SaveChanges();
        }

        public async Task<AccountModel> GetRefreshToken(string token) => await _appDbContext.Set<AccountModel>().FirstOrDefaultAsync(x => x.RefreshToken == token);

    }
}
