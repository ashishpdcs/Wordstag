using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Wordstag.API.Request.User;
using Wordstag.Services.Entities.User;
using Wordstag.Services.Interfaces;
using Wordstag.Utility;

namespace Wordstag.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRegisterController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserRegisterService _userRegisterService;
        public UserRegisterController(IUserRegisterService userRegisterService, IMapper mapper)
        {
            _mapper = mapper;
            _userRegisterService = userRegisterService;
        }

        [HttpPost("GetUserRegister")]
        public async Task<Dictionary<string, object>> GetUserRegister([FromBody] GetUserRegisterRequest request)
        {
            var userdto = _mapper.Map<GetUserRegisterRequest, GetUserRegisterDto>(request);
            var result = await _userRegisterService.GetUserRegister(userdto);
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }
        [HttpPost("GetAllUserRegister")]
        public async Task<Dictionary<string, object>> GetAllUserRegister()
        {
            var result = await _userRegisterService.GetAllUserRegister();
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }

        [HttpPost("SaveUserRegister")]
        public async Task<Dictionary<string, object>> SaveUserRegister([FromBody] SaveUserRegisterRequest request)
        {
            var saveUserRegisterDto = _mapper.Map<SaveUserRegisterRequest, SaveUserRegisterDto>(request);
            var result = await _userRegisterService.SaveUserRegister(saveUserRegisterDto);
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }
        [HttpPost("UpdateUserRegister")]
        public async Task<Dictionary<string, object>> UpdateUserRegister([FromBody] UpdateUserRegisterRequest request)
        {
            var updateUserRegisterDto = _mapper.Map<UpdateUserRegisterRequest, UpdateUserRegisterDto>(request);
            var result = await _userRegisterService.UpdateUserRegister(updateUserRegisterDto);
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }
        //[HttpPost("DeleteUserRegister")]
        //public async Task<Dictionary<string, object>> DeleteUserRegister([FromBody] DeleteUserRegisterRequest request)
        //{
        //    var deleteUserRegister = _mapper.Map<DeleteUserRegisterRequest, DeleteUserRegisterDto>(request);
        //    var result = await _userRegisterService.DeleteUserRegister(deleteUserRegister);
        //    return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        //}

    }
}
