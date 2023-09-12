using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Wordstag.API.Request.ContactUs;
using Wordstag.API.Request.Product;
using Wordstag.Services.Entities.ContactUs;
using Wordstag.Services.Entities.Product;
using Wordstag.Services.Interfaces;
using Wordstag.Services.Services;
using Wordstag.Utility;

namespace Wordstag.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactusController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IContactUsService _contactUsService;
        public ContactusController(IContactUsService contactUsService, IMapper mapper)
        {
            _mapper = mapper;
            _contactUsService = contactUsService;
        }
        [HttpPost("SaveContactUs")]
        public async Task<Dictionary<string, object>> SaveContactUs([FromBody] SaveContactUsRequest request)
        {
            var saveContactUsDto = _mapper.Map<SaveContactUsRequest, SaveContactUsDto>(request);
            var result = await _contactUsService.SaveContactUs(saveContactUsDto);
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }
    }
}
