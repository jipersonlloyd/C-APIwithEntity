using C_BackendEntity.Model;
using System.Security.Claims;

namespace C_BackendEntity.Services.Interface
{
    public interface ITokenService
    {
        string GenerateAccessToken(IEnumerable<Claim> claims);
        string GenerateRefreshToken();
        DateTime SetRefreshTokenTime();
    }
}
