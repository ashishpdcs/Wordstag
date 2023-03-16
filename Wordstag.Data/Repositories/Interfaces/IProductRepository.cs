using Wordstag.Data.Contexts;
using Wordstag.Domain.Entities.Product;

namespace Wordstag.Data.Repositories.Interfaces
{
    public interface IProductRepository<TContext> : IBaseRepository<Product, TContext> where TContext : IBaseContext
    {
    

    }
}
