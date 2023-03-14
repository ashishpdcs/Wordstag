using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Wordstag.API.Request.Master;
using Wordstag.Services.Entities.Master;
using Wordstag.Services.Interfaces;
using Wordstag.Utility;

namespace NewProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMasterService _adminLoginService;

        public MasterController(IMasterService adminLoginService, IMapper mapper)
        {
            _mapper = mapper;
            _adminLoginService = adminLoginService;
        }
      
        [HttpPost("GetCountry")]
        public async Task<Dictionary<string, object>> GetCountry()
        {
            var result = await _adminLoginService.GetCountry();
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }

        [HttpPost("GetState")]
        public async Task<Dictionary<string, object>> GetState([FromBody] StateMasterRequest request)
        {
            var statedto = _mapper.Map<StateMasterRequest, StateMasterDto>(request);
            var result = await _adminLoginService.GetState(statedto);
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }

        [HttpPost("GetCity")]
        public async Task<Dictionary<string, object>> GetCity([FromBody] CityMasterRequest request)
        {
            var citydto = _mapper.Map<CityMasterRequest, CityMasterDto>(request);
            var result = await _adminLoginService.GetCity(citydto);
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }
    }
}
