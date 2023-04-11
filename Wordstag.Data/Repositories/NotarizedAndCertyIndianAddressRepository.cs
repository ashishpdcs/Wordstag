using Wordstag.Data.Contexts;
using Wordstag.Data.Repositories.Interfaces;
using Wordstag.Domain.Entities.Product;

namespace Wordstag.Data.Repositories
{
    public class NotarizedAndCertyIndianAddressRepository<TContext> : BaseRepository<NotarizedAndCertyIndianAddress, TContext>, INotarizedAndCertyIndianAddressRepository<TContext> where TContext : IBaseContext
    {
        public NotarizedAndCertyIndianAddressRepository(TContext unit) : base(unit)
        {

        }

    }
}
