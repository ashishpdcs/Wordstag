using Wordstag.Services.Entities.Order;

namespace Wordstag.Services.Interfaces
{
    public interface IOrderService
    {
        Task<List<GetOrderDto>> GetOrder(GetOrderDto request);
        Task<List<GetOrderDto>> GetAllOrder();
        Task<Guid> SaveOrder(SaveOrderDto request);   
        Task<bool> UpdateOrder(UpdateOrderDto request);
        Task<bool> DeleteOrder(DeleteOrderDto request);

    }
}
