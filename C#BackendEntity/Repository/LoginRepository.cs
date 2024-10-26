using C_BackendEntity.Data;
using C_BackendEntity.Model;
using C_BackendEntity.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace C_BackendEntity.Services
{
    public class LoginRepository<T> : ILoginRepository<T> where T : class
    {
        private readonly AppDbContext _appDbContext;
        public LoginRepository(AppDbContext appDbContext) 
        {
            _appDbContext = appDbContext;
        }

        public async Task<T> IsAccountExist(Expression<Func<T, bool>> predicate) => await _appDbContext.Set<T>().FirstOrDefaultAsync(predicate);

    }
}
