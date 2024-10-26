using C_BackendEntity.Model;

namespace C_BackendEntity.Services
{
    public interface ILoginService
    {
        Task<LoginModel> IsAccountExist(string email);
    }
}
