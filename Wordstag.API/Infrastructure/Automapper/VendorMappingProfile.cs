using AutoMapper;
using Wordstag.API.Request.User;
using Wordstag.API.Request.Vendor;
using Wordstag.Domain.Entities.User;
using Wordstag.Domain.Entities.Vendor;
using Wordstag.Services.Entities.User;
using Wordstag.Services.Entities.Vendor;

namespace Wordstag.API.Infrastructure.Automapper
{
    public class VendorMappingProfile :Profile
    {
        public VendorMappingProfile()
        {
            CreateMap<SaveVendorRequest, SaveVendorDto>();
            CreateMap<VendorRegister, SaveVendorDto>().ReverseMap();

            CreateMap<UpdateVendorRequest, UpdateVendorDto>();
            CreateMap<VendorRegister, UpdateVendorDto>().ReverseMap();

            CreateMap<DeleteVendorRequest, DeleteVendorDto>();
            CreateMap<VendorRegister, DeleteVendorDto>().ReverseMap();
        }
    }
}
