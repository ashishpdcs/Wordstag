using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordstag.Data.Contexts;
using Wordstag.Data.Repositories.Interfaces;
using Wordstag.Domain.Entities.Product;
using Wordstag.Domain.Entities.User;

namespace Wordstag.Data.Repositories
{
    public class ProductServiceRepository<TContext> : BaseRepository<ProductServicetbl, TContext>, IProductServiceRepository<TContext> where TContext : IBaseContext
    {
        public ProductServiceRepository(TContext context) : base(context)
        {
        }

    }
}
