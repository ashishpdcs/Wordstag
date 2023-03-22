using Wordstag.Data.Contexts;
using Wordstag.Domain.Entities.Order;

namespace Wordstag.Data.Repositories.Interfaces
{
    public interface IOrderRepository<TContext> : IBaseRepository<Order, TContext> where TContext : IBaseContext
    {
    

    }
}
