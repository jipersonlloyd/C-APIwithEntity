using System.Linq.Expressions;

namespace C_BackendEntity.Repository
{
    public interface ILoginRepository<T> where T : class
    {
        Task<T> IsAccountExist(Expression<Func<T, bool>> predicate);
    }
}
