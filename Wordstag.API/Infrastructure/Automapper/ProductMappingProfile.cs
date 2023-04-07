using AutoMapper;
using Wordstag.API.Request.Product;
using Wordstag.Domain.Entities.Product;
using Wordstag.Services.Entities.Product;

namespace Wordstag.API.Infrastructure.Automapper
{
    public class ProductMappingProfile : Profile
    {
        public  ProductMappingProfile()
        {
            CreateMap<GetProductRequest, GetProductDto>();
            CreateMap<Product, GetProductDto>().ReverseMap();

            CreateMap<SaveProductRequest, SaveProductDto>();
            CreateMap<Product, SaveProductDto>().ReverseMap();

            CreateMap<UpdateProductRequest, UpdateProductDto>();
            CreateMap<Product, UpdateProductDto>().ReverseMap();

            CreateMap<DeleteProductRequest, DeleteProductDto>();
            CreateMap<Product, DeleteProductDto>().ReverseMap();

            CreateMap<Plan, GetPlanDto>();
            CreateMap<GetProductFilterRequest, GetProductDto>();
        }
    }
}

