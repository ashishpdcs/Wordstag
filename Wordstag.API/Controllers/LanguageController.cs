using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
    public class LanguageController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILanguageService _LanguageService;
        public LanguageController(ILanguageService LanguageService, IMapper mapper)
        {
            _mapper = mapper;
            _LanguageService = LanguageService;
        }
        [HttpPost("GetLanguage")]
        public async Task<Dictionary<string, object>> GetLanguage([FromBody] GetLanguageRequest request)
        {
            var userdto = _mapper.Map<GetLanguageRequest, GetLanguageDto>(request);
            var result = await _LanguageService.GetLanguage(userdto);
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }
        [HttpPost("GetAllLanguage")]
        public async Task<Dictionary<string, object>> GetAllLanguage(PaginationDto paginationDto)
        {
            var result = await _LanguageService.GetAllLanguage(paginationDto);
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }

        [HttpPost("SaveLanguage")]
        public async Task<Dictionary<string, object>> SaveLanguage([FromBody] SaveLanguageRequest request)
        {
            var saveLanguageDto = _mapper.Map<SaveLanguageRequest, SaveLanguageDto>(request);
            var result = await _LanguageService.SaveLanguage(saveLanguageDto);
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }
        [HttpPost("UpdateLanguage")]
        public async Task<Dictionary<string, object>> UpdateLanguage([FromBody] UpdateLanguageRequest request)
        {
            var updateLanguageDto = _mapper.Map<UpdateLanguageRequest, UpdateLanguageDto>(request);
            var result = await _LanguageService.UpdateLanguage(updateLanguageDto);
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }
        //[HttpPost("DeleteLanguage")]
        //public async Task<Dictionary<string, object>> DeleteLanguage([FromBody] DeleteLanguageRequest request)
        //{
        //    var deleteLanguage = _mapper.Map<DeleteLanguageRequest, DeleteLanguageDto>(request);
        //    var result = await _LanguageService.DeleteLanguage(deleteLanguage);
        //    return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        //}
    }
}
