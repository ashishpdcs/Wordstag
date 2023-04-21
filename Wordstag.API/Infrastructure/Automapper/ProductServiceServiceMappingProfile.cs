using AutoMapper;
using Wordstag.API.Request.Product;
using Wordstag.Domain.Entities.Product;
using Wordstag.Services.Entities.Product;

namespace Wordstag.API.Infrastructure.Automapper
{
    public class ProductServiceServiceMappingProfile:Profile
    {
        public ProductServiceServiceMappingProfile()
        {
            CreateMap<SaveProductservicesevice, SaveProductServiceDto>();
            CreateMap<ProductServicetbl, SaveProductServiceDto>().ReverseMap();

            CreateMap<GetProductservicesevice, ProductServiceDto>();
            CreateMap<ProductServicetbl, GetProductservicesevice>().ReverseMap();
        }
    }
}
