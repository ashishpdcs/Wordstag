using Wordstag.Data.Contexts;
using Wordstag.Data.Repositories.Interfaces;
using Wordstag.Domain.Entities.Product;

namespace Wordstag.Data.Repositories
{
    public class PlanRepository<TContext> : BaseRepository<Plan, TContext>, IPlanRepository<TContext> where TContext : IBaseContext
    {
        public PlanRepository(TContext unit) : base(unit)
        {

        }

    }
}
