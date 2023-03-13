using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Wordstag.Data.Infrastructure;
using Wordstag.Utility;

namespace Wordstag.Data.Contexts
{
    public class AuditLogDbContext : BaseDBContext, IBaseContext
    {
        private readonly IUnitOfWork<MasterDbContext> _context;
        private readonly IHttpContextAccessor _accessor;
        private readonly IConfiguration _configuration;

        public AuditLogDbContext(IConfiguration configuration, IHttpContextAccessor accessor,
            IUnitOfWork<MasterDbContext> context)
            : base()
        {
            _configuration = configuration;
            _accessor = accessor;
            _context = context;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var subdomain = _accessor.HttpContext.Request.Headers[Constants.SubDomainNameField];

                var account = this._context.AccountsRepository.GetFirstOrDefaultAsync(c => c.Subdomain == Convert.ToString(subdomain)).Result;

                if (account == null)
                {
                    account = new Domain.Entities.Master.Account();

                    account.DbDomain = Constants.Shared;
                }
                optionsBuilder.UseSqlServer(_configuration.GetSection("ClientConnectionStrings:" + account.DbDomain + ":" + Constants.AuditLogDBConnectionName).Value);
            }
        }

        //public DbSet<Event> Event { get; set; }
        //public DbSet<SmsLog> SmsLog { get; set; }
        //public DbSet<EmailAudit> EmailAudit { get; set; }
    }
}
