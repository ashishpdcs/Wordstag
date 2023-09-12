using AutoMapper;
using Wordstag.API.Request.ContactUs;
using Wordstag.API.Request.Product;
using Wordstag.Domain.Entities.ContactUs;
using Wordstag.Services.Entities.ContactUs;
using Wordstag.Services.Entities.Product;

namespace Wordstag.API.Infrastructure.Automapper
{
    public class ContactUsMappingProfile:Profile
    {
        public ContactUsMappingProfile()
        {
            CreateMap<SaveContactUsRequest, SaveContactUsDto>();
            CreateMap<ContactUs, SaveContactUsDto>().ReverseMap();

           
        }
    }
}
