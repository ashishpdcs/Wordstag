using AutoMapper;
using Wordstag.API.Request.Product;
using Wordstag.Domain.Entities.Product;
using Wordstag.Services.Entities.Product;

namespace Wordstag.API.Infrastructure.Automapper
{
    public class ProductCertificateMappingProfile : Profile
    {
        public ProductCertificateMappingProfile()
        {
            CreateMap<SaveProductCertificateRequest, SaveProductCertificateDto>();
            CreateMap<ProductCertificate, SaveProductCertificateDto>().ReverseMap();

            CreateMap<GetProductCertificateRequest, GetProductCertificateDto>();
            CreateMap<ProductCertificate, GetProductCertificateDto>().ReverseMap();

            CreateMap<UpdateProductCertificateRequest, UpdateProductCertificateDto>();
            CreateMap<ProductCertificate, UpdateProductCertificateDto>().ReverseMap();


        }
    }
}

