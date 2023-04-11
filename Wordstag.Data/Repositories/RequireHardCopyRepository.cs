using Wordstag.Data.Contexts;
using Wordstag.Data.Repositories.Interfaces;
using Wordstag.Domain.Entities.Product;

namespace Wordstag.Data.Repositories
{
    public class RequireHardCopyRepository<TContext> : BaseRepository<RequireHardCopy, TContext>, IRequireHardCopyRepository<TContext> where TContext : IBaseContext
    {
        public RequireHardCopyRepository(TContext unit) : base(unit)
        {

        }

    }
}
