
using Wordstag.Domain.Entities.User;
using Wordstag.Services.Entities.User;
using Wordstag.Utility;

namespace Wordstag.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateSecurityToken(SessionDetailsDto sessionDetailsDto, AppSettings appSettings, out DateTime expiresOn);
        //public SessionDetailsDto ValidateJwtToken(string token);
        public RefreshToken GenerateRefreshToken(string ipAddress);
    }
}
