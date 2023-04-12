using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Ocsp;
using Wordstag.API.Request.Product;
using Wordstag.Domain.Entities.Product;
using Wordstag.Services.Entities.Common;
using Wordstag.Services.Entities.Product;
using Wordstag.Services.Interfaces;
using Wordstag.Services.Services;
using Wordstag.Utility;

namespace Wordstag.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotarizedAndCertyIndianAddressController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly INotarizedAndCertyIndianAddressService _notarizedAndCertyIndianAddressService;
        public NotarizedAndCertyIndianAddressController(INotarizedAndCertyIndianAddressService notarizedAndCertyIndianAddressService, IMapper mapper)
        {
            _mapper = mapper;
            _notarizedAndCertyIndianAddressService = notarizedAndCertyIndianAddressService;
        }
       
        [HttpPost("SaveNotarizedAndCertyIndianAddress")]
        public async Task<Dictionary<string, object>> SaveNotarizedAndCertyIndianAddress([FromBody] SaveNotarizedAndCertyIndianAddressRequest request)
        {
            var data = _mapper.Map<SaveNotarizedAndCertyIndianAddressRequest, SaveNotarizedAndCertyIndianAddressDto>(request);
            var result = await _notarizedAndCertyIndianAddressService.SaveNotarizedAndCertyIndianAddress(data);
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }

        [HttpPost("GetNotarizedAndCertyIndianAddress")]
        public async Task<Dictionary<string, object>> GetNotarizedAndCertyIndianAddress([FromBody] GetNotarizedAndCertyIndianAddressRequest request)
        {
            var data = _mapper.Map<GetNotarizedAndCertyIndianAddressRequest, GetNotarizedAndCertyIndianAddressDto>(request);
            var result = await _notarizedAndCertyIndianAddressService.GetNotarizedAndCertyIndianAddress(data);
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }

        [HttpPost("GetAllNotarizedAndCertyIndianAddress")]
        public async Task<Dictionary<string, object>> GetAllNotarizedAndCertyIndianAddress()
        {
            var result = await _notarizedAndCertyIndianAddressService.GetAllNotarizedAndCertyIndianAddress();
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }

        [HttpPost("UpdateNotarizedAndCertyIndianAddress")]
        public async Task<Dictionary<string, object>> UpdateNotarizedAndCertyIndianAddress([FromBody] UpdateNotarizedAndCertyIndianAddressRequest request)
        {
            var data = _mapper.Map<UpdateNotarizedAndCertyIndianAddressRequest, UpdateNotarizedAndCertyIndianAddressDto>(request);
            var result = await _notarizedAndCertyIndianAddressService.UpdateNotarizedAndCertyIndianAddress(data);
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }

        [HttpPost("DeleteNotarizedAndCertyIndianAddress")]
        public async Task<Dictionary<string, object>> DeleteNotarizedAndCertyIndianAddress([FromBody] DeleteNotarizedAndCertyIndianAddressRequest request)
        {
            var data = _mapper.Map<DeleteNotarizedAndCertyIndianAddressRequest, DeleteNotarizedAndCertyIndianAddressDto>(request);
            var result = await _notarizedAndCertyIndianAddressService.DeleteNotarizedAndCertyIndianAddress(data);
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }



    }
}
