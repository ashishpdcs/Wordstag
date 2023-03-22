using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Wordstag.API.Request.User;
using Wordstag.API.Requests.User;
using Wordstag.Services.Entities.Upload;
using Wordstag.Services.Entities.User;
using Wordstag.Services.Interfaces;
using Wordstag.Services.Services;
using Wordstag.Utility;

namespace Wordstag.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserRegisterService _userRegisterService;
        private readonly IUploadService _UploadService;

        public AdminController(IUserRegisterService userRegisterService, IUploadService UploadService, IMapper mapper)
        {
            _mapper = mapper;
            _userRegisterService = userRegisterService;
            _UploadService = UploadService;
        }
        [HttpPost("GetAdminRegister")]
        public async Task<Dictionary<string, object>> GetAdminRegister([FromBody] GetUserRegisterRequest request)
        {
            var userdto = _mapper.Map<GetUserRegisterRequest, GetUserRegisterDto>(request);
            var result = await _userRegisterService.GetUserRegister(userdto);
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }
        [HttpPost("GetAllUser")]
        public async Task<Dictionary<string, object>> GetAllUser()
        {
            var result = await _userRegisterService.GetAllUserRegister();
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }
        [HttpPost("GetAllUpload")]
        public async Task<Dictionary<string, object>> GetAllUpload()
        {
            var result = await _UploadService.GetAllUpload();
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }
        [HttpPost("GetUserUpload")]
        public async Task<Dictionary<string, object>> GetUserUpload(Guid UserId)
        {
            var result = await _UploadService.GetUserUpload(UserId);
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }
    }
}
