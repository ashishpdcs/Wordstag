using Wordstag.Services.Entities;
using Wordstag.Services.Entities.Common;
using Wordstag.Services.Entities.Product;

namespace Wordstag.Services.Interfaces
{
    public interface IProductTypeService
    {
        Task<List<GetProductTypeDto>> GetProductType(GetProductTypeDto request);
        Task<GenericList<GetProductTypeDto>> GetAllProductType(PaginationDto paginationDto);
        Task<Guid> SaveProductType(SaveProductTypeDto request);   
        Task<bool> UpdateProductType(UpdateProductTypeDto request);
        Task<bool> DeleteProductType(DeleteProductTypeDto request);

    }
}
