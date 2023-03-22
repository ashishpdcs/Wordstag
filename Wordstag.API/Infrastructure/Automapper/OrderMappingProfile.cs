using AutoMapper;
using Wordstag.API.Request.Order;
using Wordstag.Domain.Entities.Order;
using Wordstag.Services.Entities.Order;

namespace Wordstag.API.Infrastructure.Automapper
{
    public class OrderMappingProfile : Profile
    {
        public  OrderMappingProfile()
        {
            CreateMap<GetOrderRequest, GetOrderDto>();
            CreateMap<Order, GetOrderDto>().ReverseMap();

            CreateMap<SaveOrderRequest, SaveOrderDto>();
            CreateMap<Order, SaveOrderDto>().ReverseMap();

            CreateMap<UpdateOrderRequest, UpdateOrderDto>();
            CreateMap<Order, UpdateOrderDto>().ReverseMap();

            CreateMap<DeleteOrderRequest, DeleteOrderDto>();
            CreateMap<Order, DeleteOrderDto>().ReverseMap();
        }
    }
}

