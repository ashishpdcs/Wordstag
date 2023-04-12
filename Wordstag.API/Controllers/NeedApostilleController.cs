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
    public class NeedApostilleController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly INeedApostilleService _needApostilleService;
        public NeedApostilleController(INeedApostilleService needApostilleService, IMapper mapper)
        {
            _mapper = mapper;
            _needApostilleService = needApostilleService;
        }
       
        [HttpPost("SaveNeedApostille")]
        public async Task<Dictionary<string, object>> SaveNeedApostille([FromBody] SaveNeedApostilleRequest request)
        {
            var saveneedApostilleDto = _mapper.Map<SaveNeedApostilleRequest, SaveNeedApostilleDto>(request);
            var result = await _needApostilleService.SaveNeedApostille(saveneedApostilleDto);
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }

        [HttpPost("GetNeedApostille")]
        public async Task<Dictionary<string, object>> GetNeedApostille([FromBody] GetNeedApostilleRequest request)
        {
            var getneedApostilleDto = _mapper.Map<GetNeedApostilleRequest, GetNeedApostilleDto>(request);
            var result = await _needApostilleService.GetNeedApostille(getneedApostilleDto);
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }

        [HttpPost("GetAllNeedApostille")]
        public async Task<Dictionary<string, object>> GetAllNeedApostille()
        {
            var result = await _needApostilleService.GetAllNeedApostille();
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }

        [HttpPost("UpdateNeedApostille")]
        public async Task<Dictionary<string, object>> UpdateNeedApostille([FromBody] UpdateNeedApostilleRequest request)
        {
            var updateNeedApostilleDto = _mapper.Map<UpdateNeedApostilleRequest, UpdateNeedApostilleDto>(request);
            var result = await _needApostilleService.UpdateNeedApostille(updateNeedApostilleDto);
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }

        [HttpPost("DeleteNeedApostille")]
        public async Task<Dictionary<string, object>> DeleteNeedApostille([FromBody] DeleteNeedApostilleRequest request)
        {
            var deleteNeedApostilleDto = _mapper.Map<DeleteNeedApostilleRequest, DeleteNeedApostilleDto>(request);
            var result = await _needApostilleService.DeleteNeedApostille(deleteNeedApostilleDto);
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }



    }
}
