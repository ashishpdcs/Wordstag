using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Wordstag.API.Requests.User;
using Wordstag.Services.Entities.User;
using Wordstag.Services.Interfaces;
using Wordstag.Utility;

namespace Wordstag.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _authenticationService;
        public AccountController(IAuthenticationService authenticationService, IMapper mapper)
        {
            _authenticationService = authenticationService;
            _mapper = mapper;
        }
        [HttpPost("authenticate")]
        public async Task<Dictionary<string, object>> AuthenticateAsync([FromBody] UserAuthRequest request)
        {
            var userDto = _mapper.Map<UserAuthRequest, UserAuthRequestDto>(request);
            var result = await _authenticationService.AuthenticateAsync(userDto, GetIdAddress());

            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }
        #region Helper
        private string GetIdAddress()
        {
            // get source ip address for the current request
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
        #endregion
    }
}

