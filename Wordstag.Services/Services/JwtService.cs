using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Wordstag.Services.Entities.User;
using Wordstag.Services.Interfaces;
using Wordstag.Utility;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Wordstag.Domain.Entities.User;

namespace Wordstag.Services.Services
{
    public class JwtService : IJwtService
    {
        private readonly AppSettings _appSettings;
        public JwtService(IOptions<AppSettings> appSettings)
        {
            this._appSettings = appSettings.Value;
        }
        public string GenerateSecurityToken(SessionDetailsDto sessionDetailsDto, AppSettings appSettings, out DateTime expiresOn)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            expiresOn = DateTime.UtcNow.AddMinutes(double.Parse(appSettings.JwtExpiryInMinutes));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(Constants.JwtTokenClaimKey, System.Text.Json.JsonSerializer.Serialize(sessionDetailsDto)) }),
                Expires = expiresOn,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public SessionDetailsDto ValidateJwtToken(string token)
        {
            if (token == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;

                var sessionDetailsDto = JsonConvert.DeserializeObject<SessionDetailsDto>
                    (jwtToken.Claims.First(x => x.Type == Constants.JwtTokenClaimKey).Value);

                // return user id from JWT token if validation successful
                return sessionDetailsDto;
            }
            catch
            {
                // return null if validation fails
                return null;
            }
        }

        public RefreshToken GenerateRefreshToken(string ipAddress)
        {
            // generate token that is valid for 7 days
            using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            var randomBytes = new byte[64];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            var refreshToken = new RefreshToken
            {
                Token = Convert.ToBase64String(randomBytes),
                Expires = DateTime.UtcNow.AddDays(7),
                Created = DateTime.UtcNow,
                CreatedByIp = ipAddress
            };

            return refreshToken;
        }
    }
}

