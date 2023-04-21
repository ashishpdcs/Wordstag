using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordstag.Services.Entities.Product;

namespace Wordstag.Services.Interfaces
{
    public interface IProductServicesService
    {
        Task<List<ProductServiceDto>> GetProductServiceService(ProductServiceDto productServiceDto );
        Task<int> SaveProductServiceService(SaveProductServiceDto saveProductServiceDto);
    }
}
