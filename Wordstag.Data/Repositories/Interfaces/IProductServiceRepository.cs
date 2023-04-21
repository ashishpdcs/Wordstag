using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordstag.Data.Contexts;
using Wordstag.Domain.Entities.Product;
using Wordstag.Domain.Entities.Upload;

namespace Wordstag.Data.Repositories.Interfaces
{
    public interface IProductServiceRepository<TContext> : IBaseRepository<ProductServicetbl, TContext> where TContext : IBaseContext
    {
    }
}
