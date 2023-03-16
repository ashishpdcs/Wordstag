using Wordstag.Data.Contexts;
using Wordstag.Data.Repositories.Interfaces;
using Wordstag.Domain.Entities.Product;

namespace Wordstag.Data.Repositories
{
    public class ProductTypeRepository<TContext> : BaseRepository<ProductType, TContext>, IProductTypeRepository<TContext> where TContext : IBaseContext
    {
        public ProductTypeRepository(TContext unit) : base(unit)
        {

        }

    }
}
