
namespace Wordstag.Utility
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public string SubDomain { get; set; }
        public string JwtExpiryInMinutes { get; set; }
        public int RefreshTokenTTL { get; set; }
      
    }
}
