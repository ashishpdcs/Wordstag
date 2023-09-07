using Wordstag.Data.Contexts;
using Wordstag.Data.Repositories.Interfaces;
using Wordstag.Domain.Entities.Vendor;

namespace Wordstag.Data.Repositories
{
    public class VendorRegisterRepository<TContext> : BaseRepository<VendorRegister, TContext>, IVendorRegisterRepository<TContext> where TContext : IBaseContext
    {
        public VendorRegisterRepository(TContext unit) : base(unit)
        {

        }
    }
}
