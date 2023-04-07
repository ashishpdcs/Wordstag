using Wordstag.Services.Entities;
using Wordstag.Services.Entities.Common;
using Wordstag.Services.Entities.Product;

namespace Wordstag.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<GetProductDto>> GetProduct(GetProductDto request);
        Task<List<GetProductDto>> GetAllProduct(GetProductDto request);
        Task<GenericList<GetProductDto>> GetAllProductWithPagination(PaginationDto paginationDto);
        Task<Guid> SaveProduct(SaveProductDto request);   
        Task<bool> UpdateProduct(UpdateProductDto request);
        Task<bool> DeleteProduct(DeleteProductDto request);

    }
}
