using Wordstag.Data.Contexts;
using Wordstag.Data.Repositories.Interfaces;
using Wordstag.Domain.Entities.Product;

namespace Wordstag.Data.Repositories
{
    public class NeedApostilleRepository<TContext> : BaseRepository<NeedApostille, TContext>, INeedApostilleRepository<TContext> where TContext : IBaseContext
    {
        public NeedApostilleRepository(TContext unit) : base(unit)
        {

        }

    }
}
