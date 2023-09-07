using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wordstag.API.Request.User;
using Wordstag.API.Request.UserSample;
using Wordstag.API.Request.Vendor;
using Wordstag.Services.Entities.Common;
using Wordstag.Services.Entities.User;
using Wordstag.Services.Entities.UserSample;
using Wordstag.Services.Entities.Vendor;
using Wordstag.Services.Interfaces;
using Wordstag.Services.Services;
using Wordstag.Utility;

namespace Wordstag.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IVendorRegisterService _vendorRegisterService;
        public VendorController(IVendorRegisterService vendorRegisterService, IMapper mapper)
        {
            _mapper = mapper;
           _vendorRegisterService = vendorRegisterService;
        }
        [HttpPost("SaveVendorRegister")]
        public async Task<Dictionary<string, object>> SaveUserRegister([FromBody] SaveVendorRequest request)
        {
            var saveVendorRegisterDto = _mapper.Map<SaveVendorRequest, SaveVendorDto>(request);
            var result = await _vendorRegisterService.SaveVendorRegister(saveVendorRegisterDto);
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }
        [HttpPost("UpdateVendorRegister")]
        public async Task<Dictionary<string, object>> UpdateVendorRegister([FromBody] UpdateVendorRequest request)
        {
            var updateVendorRegisterDto = _mapper.Map<UpdateVendorRequest, UpdateVendorDto>(request);
            var result = await _vendorRegisterService.UpdateVendorRegister(updateVendorRegisterDto);
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }
        [HttpPost("DeleteVendorRegister")]
        public async Task<Dictionary<string, object>> DeleteVendorRegister([FromBody] DeleteVendorRequest request)
        {
            var deleteVendorRegisterDto = _mapper.Map<DeleteVendorRequest, DeleteVendorDto>(request);
            var result = await _vendorRegisterService.DeleteVendorRegister(deleteVendorRegisterDto);
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }
		[HttpPost("GetVendorSkill")]
		public async Task<Dictionary<string, object>> GetVendorSkill([FromBody] GetVendorSkillRequest request)
		{
			var result = await _vendorRegisterService.GetVendorSkill(request.VendorSkillId);
			return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
		}
		[HttpPost("GetAllVendorSkill")]
		public async Task<Dictionary<string, object>> GetAllVendorSkill()
		{
			var result = await _vendorRegisterService.GetAllVendorSkill();
			return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
		}
	}
}
