using Wordstag.Data.Contexts;
using Wordstag.Domain.Entities.Product;

namespace Wordstag.Data.Repositories.Interfaces
{
    public interface IPlanRepository<TContext> : IBaseRepository<Plan, TContext> where TContext : IBaseContext
    {
    

    }
}
