using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Wordstag.API.Request.UserSample;
using Wordstag.Services.Entities.UserSample;
using Wordstag.Services.Interfaces;
using Wordstag.Utility;

namespace Wordstag.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserSampleController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserSampleService _UserSampleService;
        public UserSampleController(IUserSampleService UserSampleService, IMapper mapper)
        {
            _mapper = mapper;
            _UserSampleService = UserSampleService;
        }
        [HttpPost("GetUserSample")]
        public async Task<Dictionary<string, object>> GetUserSample([FromBody] GetUserSampleRequest request)
        {
            var userdto = _mapper.Map<GetUserSampleRequest, GetUserSampleDto>(request);
            var result = await _UserSampleService.GetUserSample(userdto);
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }
        [HttpPost("GetAllUserSample")]
        public async Task<Dictionary<string, object>> GetAllUserSample()
        {
            var result = await _UserSampleService.GetAllUserSample();
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }

        [HttpPost("SaveUserSample")]
        public async Task<Dictionary<string, object>> SaveUserSample([FromBody] SaveUserSampleRequest request)
        {
            var saveUserSampleDto = _mapper.Map<SaveUserSampleRequest, SaveUserSampleDto>(request);
            var result = await _UserSampleService.SaveUserSample(saveUserSampleDto);
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }
        [HttpPost("UpdateUserSample")]
        public async Task<Dictionary<string, object>> UpdateUserSample([FromBody] UpdateUserSampleRequest request)
        {
            var updateUserSampleDto = _mapper.Map<UpdateUserSampleRequest, UpdateUserSampleDto>(request);
            var result = await _UserSampleService.UpdateUserSample(updateUserSampleDto);
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }
        [HttpPost("DeleteUserSample")]
        public async Task<Dictionary<string, object>> DeleteUserSample([FromBody] DeleteUserSampleRequest request)
        {
            var deleteUserSample = _mapper.Map<DeleteUserSampleRequest, DeleteUserSampleDto>(request);
            var result = await _UserSampleService.DeleteUserSample(deleteUserSample);
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }
    }
}
