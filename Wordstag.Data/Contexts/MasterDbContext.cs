
using Audit.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Wordstag.Data.Contexts;

namespace Wordstag.Data.Contexts
{
    [AuditDbContext(AuditEventType = "{database}")]
    public class MasterDbContext : AuditDbContext, IBaseContext
    {
        internal MasterDbContext(DbContextOptions options)
         : base(options)
        {
        }

        public MasterDbContext(DbContextOptions<MasterDbContext> options)
            : base(options)
        {
        }
    }
}
