using Microsoft.AspNetCore.Identity;

namespace FirstRestfulAPI.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
