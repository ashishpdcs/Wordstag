using AutoMapper;
using Wordstag.API.Request.Product;
using Wordstag.Domain.Entities.Product;
using Wordstag.Services.Entities.Product;

namespace Wordstag.API.Infrastructure.Automapper
{
    public class NotarizedAndCertyIndianAddressMappingProfile : Profile
    {
        public NotarizedAndCertyIndianAddressMappingProfile()
        {
            CreateMap<SaveNotarizedAndCertyIndianAddressRequest, SaveNotarizedAndCertyIndianAddressDto>();
            CreateMap<NotarizedAndCertyIndianAddress, SaveNotarizedAndCertyIndianAddressDto>().ReverseMap();
            CreateMap<GetNotarizedAndCertyIndianAddressRequest, GetNotarizedAndCertyIndianAddressDto>();
            CreateMap<NotarizedAndCertyIndianAddress, GetNotarizedAndCertyIndianAddressDto>().ReverseMap();
            CreateMap<UpdateNotarizedAndCertyIndianAddressRequest, UpdateNotarizedAndCertyIndianAddressDto>();
            CreateMap<NotarizedAndCertyIndianAddress, UpdateNotarizedAndCertyIndianAddressDto>().ReverseMap();
            CreateMap<DeleteNotarizedAndCertyIndianAddressRequest, DeleteNotarizedAndCertyIndianAddressDto>();
            CreateMap<NotarizedAndCertyIndianAddress, DeleteNotarizedAndCertyIndianAddressDto>().ReverseMap();





        }
    }
}

