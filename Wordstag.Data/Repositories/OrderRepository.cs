using Wordstag.Data.Contexts;
using Wordstag.Data.Repositories.Interfaces;
using Wordstag.Domain.Entities.Order;

namespace Wordstag.Data.Repositories
{
    public class OrderRepository<TContext> : BaseRepository<Order, TContext>, IOrderRepository<TContext> where TContext : IBaseContext
    {
        public OrderRepository(TContext unit) : base(unit)
        {

        }

    }
}
