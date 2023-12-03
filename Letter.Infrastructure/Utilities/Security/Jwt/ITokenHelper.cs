using Letter.DataAccess.Entities.Users;
using System.Security.Claims;

namespace Letter.Infrastructure.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(ApplicationUser user, IList<Claim> claims);
    }
}
