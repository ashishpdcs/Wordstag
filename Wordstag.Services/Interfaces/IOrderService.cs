using Wordstag.Services.Entities;
using Wordstag.Services.Entities.Common;
using Wordstag.Services.Entities.Order;

namespace Wordstag.Services.Interfaces
{
    public interface IOrderService
    {
        Task<List<GetOrderDto>> GetOrder(GetOrderDto request);
        Task<GenericList<GetOrderDto>> GetAllOrder(PaginationDto paginationDto);
        Task<Guid> SaveOrder(SaveOrderDto request);   
        Task<bool> UpdateOrder(UpdateOrderDto request);
        Task<bool> DeleteOrder(DeleteOrderDto request);

    }
}
