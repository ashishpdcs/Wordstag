using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Wordstag.API.Request.Order;
using Wordstag.Services.Entities.Common;
using Wordstag.Services.Entities.Order;
using Wordstag.Services.Interfaces;
using Wordstag.Utility;

namespace Wordstag.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOrderService _OrderService;
        public OrderController(IOrderService OrderService, IMapper mapper)
        {
            _mapper = mapper;
            _OrderService = OrderService;
        }
        [HttpPost("GetOrder")]
        public async Task<Dictionary<string, object>> GetOrder([FromBody] GetOrderRequest request)
        {
            var userdto = _mapper.Map<GetOrderRequest, GetOrderDto>(request);
            var result = await _OrderService.GetOrder(userdto);
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }
        [HttpPost("GetAllOrder")]
        public async Task<Dictionary<string, object>> GetAllOrder(PaginationDto paginationDto)
        {
            var result = await _OrderService.GetAllOrder(paginationDto);
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }

        [HttpPost("SaveOrder")]
        public async Task<Dictionary<string, object>> SaveOrder([FromBody] SaveOrderRequest request)
        {
            var saveOrderDto = _mapper.Map<SaveOrderRequest, SaveOrderDto>(request);
            var result = await _OrderService.SaveOrder(saveOrderDto);
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }
        [HttpPost("UpdateOrder")]
        public async Task<Dictionary<string, object>> UpdateOrder([FromBody] UpdateOrderRequest request)
        {
            var updateOrderDto = _mapper.Map<UpdateOrderRequest, UpdateOrderDto>(request);
            var result = await _OrderService.UpdateOrder(updateOrderDto);
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }
        [HttpPost("DeleteOrder")]
        public async Task<Dictionary<string, object>> DeleteOrder([FromBody] DeleteOrderRequest request)
        {
            var deleteOrder = _mapper.Map<DeleteOrderRequest, DeleteOrderDto>(request);
            var result = await _OrderService.DeleteOrder(deleteOrder);
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }
    }
}
