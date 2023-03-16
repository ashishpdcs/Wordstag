using AutoMapper;
using Wordstag.API.Request.Product;
using Wordstag.Domain.Entities.Product;
using Wordstag.Services.Entities.Product;

namespace Wordstag.API.Infrastructure.Automapper
{
    public class ProductTypeMappingProfile : Profile
    {
        public  ProductTypeMappingProfile()
        {
            CreateMap<GetProductTypeRequest, GetProductTypeDto>();
            CreateMap<ProductType, GetProductTypeDto>().ReverseMap();

            CreateMap<SaveProductTypeRequest, SaveProductTypeDto>();
            CreateMap<ProductType, SaveProductTypeDto>().ReverseMap();

            CreateMap<UpdateProductTypeRequest, UpdateProductTypeDto>();
            CreateMap<ProductType, UpdateProductTypeDto>().ReverseMap();

            CreateMap<DeleteProductTypeRequest, DeleteProductTypeDto>();
            CreateMap<ProductType, DeleteProductTypeDto>().ReverseMap();
        }
    }
}

