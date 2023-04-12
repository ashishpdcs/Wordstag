using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Ocsp;
using Wordstag.API.Request.Product;
using Wordstag.Services.Entities.Common;
using Wordstag.Services.Entities.Product;
using Wordstag.Services.Interfaces;
using Wordstag.Services.Services;
using Wordstag.Utility;

namespace Wordstag.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequireHardCopyController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRequireHardCopyService _requireHardCopyService;
        public RequireHardCopyController(IRequireHardCopyService requireHardCopyService, IMapper mapper)
        {
            _mapper = mapper;
            _requireHardCopyService = requireHardCopyService;
        }
       
        [HttpPost("SaveRequireHardCopy")]
        public async Task<Dictionary<string, object>> SaveRequireHardCopy([FromBody] SaveRequireHardCopyRequest request)
        {
            var saverequiredHardCopyDto = _mapper.Map<SaveRequireHardCopyRequest, SaveRequireHardCopyDto>(request);
            var result = await _requireHardCopyService.SaveRequireHardCopy(saverequiredHardCopyDto);
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }

        [HttpPost("GetRequireHardCopy")]
        public async Task<Dictionary<string, object>> GetRequireHardCopy([FromBody] GetRequireHardCopyRequest request)
        {
            var getRequireHardCopyDto = _mapper.Map<GetRequireHardCopyRequest, GetRequireHardCopyDto>(request);
            var result = await _requireHardCopyService.GetRequireHardCopy(getRequireHardCopyDto);
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }

        [HttpPost("GetAllRequireHardCopy")]
        public async Task<Dictionary<string, object>> GetAllRequireHardCopy()
        {
            var result = await _requireHardCopyService.GetAllRequireHardCopy();
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }

        [HttpPost("UpdateRequireHardCopy")]
        public async Task<Dictionary<string, object>> UpdateRequireHardCopy([FromBody] UpdateRequireHardCopyRequest request)
        {
            var UpdateRequireHardCopyDto = _mapper.Map<UpdateRequireHardCopyRequest, UpdateRequireHardCopyDto>(request);
            var result = await _requireHardCopyService.UpdateRequireHardCopy(UpdateRequireHardCopyDto);
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }

        [HttpPost("DeleteRequireHardCopy")]
        public async Task<Dictionary<string, object>> DeleteRequireHardCopy([FromBody] DeleteRequireHardCopyRequest request)
        {
            var deleteRequireHardCopyDto = _mapper.Map<DeleteRequireHardCopyRequest, DeleteRequireHardCopyDto>(request);
            var result = await _requireHardCopyService.DeleteRequireHardCopy(deleteRequireHardCopyDto);
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }



    }
}
