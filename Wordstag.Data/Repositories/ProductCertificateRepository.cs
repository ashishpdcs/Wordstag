using Wordstag.Data.Contexts;
using Wordstag.Data.Repositories.Interfaces;
using Wordstag.Domain.Entities.Product;

namespace Wordstag.Data.Repositories
{
    public class ProductCertificateRepository<TContext> : BaseRepository<ProductCertificate, TContext>, IProductCertificateRepository<TContext> where TContext : IBaseContext
    {
        public ProductCertificateRepository(TContext unit) : base(unit)
        {

        }

    }
}
