using Wordstag.Data.Contexts;
using Wordstag.Data.Repositories.Interfaces;
using Wordstag.Domain.Entities.Product;

namespace Wordstag.Data.Repositories
{
    public class ProductRepository<TContext> : BaseRepository<Product, TContext>, IProductRepository<TContext> where TContext : IBaseContext
    {
        public ProductRepository(TContext unit) : base(unit)
        {

        }

    }
}
