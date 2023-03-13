
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Wordstag.Data.Infrastructure;
using Microsoft.AspNetCore.Http;
using Wordstag.Data.Contexts;
using Wordstag.Utility;

namespace Wordstag.Data.Contexts
{
    public class ReadOnlyApplicationDbContext : BaseDBContext, IBaseContext
    {
        internal ReadOnlyApplicationDbContext(DbContextOptions options,
            IUnitOfWork<MasterDbContext> context, IHttpContextAccessor accessor, IConfiguration configuration, IOptions<AppSettings> appSettings)
            : base(options, context, accessor, configuration, appSettings)
        {
        }

        public ReadOnlyApplicationDbContext(DbContextOptions<ReadOnlyApplicationDbContext> options,
            IUnitOfWork<MasterDbContext> context, IHttpContextAccessor accessor, IConfiguration configuration, IOptions<AppSettings> appSettings)
            : base(options, context, accessor, configuration, appSettings)
        {
        }
    }
}
