
namespace Wordstag.Utility
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public string SubDomain { get; set; }
        public string JwtExpiryInMinutes { get; set; }
        public int RefreshTokenTTL { get; set; }
        public string ConnectionString = "Data Source=wordstag.database.windows.net;User Id=wordstag;Password=admin@1234;Initial Catalog=WordstagDb;MultipleActiveResultSets=true;";

    }
}
