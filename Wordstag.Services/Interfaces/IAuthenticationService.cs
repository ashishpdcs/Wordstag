using MimeKit.Cryptography;
using Wordstag.Services.Entities.User;
using Wordstag.Services.Entities.Login;

namespace Wordstag.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<LoginDto> AuthenticateAsync(UserAuthRequestDto request, string ipAddress);

    }
}
