using Wordstag.Data.Contexts;
using Wordstag.Domain.Entities.Product;

namespace Wordstag.Data.Repositories.Interfaces
{
    public interface IProductTypeRepository<TContext> : IBaseRepository<ProductType, TContext> where TContext : IBaseContext
    {

    }
}
