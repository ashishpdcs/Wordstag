using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Wordstag.Data.Infrastructure;
using Wordstag.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordstag.Data.Contexts
{
    public class ReadWriteApplicationDbContext : BaseDBContext, IBaseContext
    {
        internal ReadWriteApplicationDbContext(DbContextOptions options,
           IUnitOfWork<MasterDbContext> context, IHttpContextAccessor accessor, IConfiguration configuration, IOptions<AppSettings> appSettings)
           : base(options, context, accessor, configuration, appSettings)
        {
        }

        public ReadWriteApplicationDbContext(DbContextOptions<ReadWriteApplicationDbContext> options,
            IUnitOfWork<MasterDbContext> context, IHttpContextAccessor accessor, IConfiguration configuration, IOptions<AppSettings> appSettings)
            : base(options, context, accessor, configuration, appSettings)
        {
        }

        public ReadWriteApplicationDbContext(DbContextOptions<ReadWriteApplicationDbContext> options)
        {
        }
    }
}
