using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Wordstag.API.Request.Upload;
using Wordstag.Services.Entities.Common;
using Wordstag.Services.Entities.Upload;
using Wordstag.Services.Interfaces;
using Wordstag.Utility;

namespace Wordstag.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUploadService _UploadService;
        public UploadController(IUploadService UploadService, IMapper mapper)
        {
            _mapper = mapper;
            _UploadService = UploadService;
        }
        [HttpPost("GetUpload")]
        public async Task<Dictionary<string, object>> GetUpload([FromBody] GetUploadRequest request)
        {
            var userdto = _mapper.Map<GetUploadRequest, GetUploadDto>(request);
            var result = await _UploadService.GetUpload(userdto);
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }
        [HttpPost("GetAllUpload")]
        public async Task<Dictionary<string, object>> GetAllUpload(PaginationDto paginationDto)
        {
            var result = await _UploadService.GetAllUpload(paginationDto);
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }

        [HttpPost("SaveUpload")]
        public async Task<Dictionary<string, object>> SaveUpload([FromBody] SaveUploadRequest request)
        {
            var saveUploadDto = _mapper.Map<SaveUploadRequest, SaveUploadDto>(request);
            var result = await _UploadService.SaveUpload(saveUploadDto);
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }
        [HttpPost("UpdateUpload")]
        public async Task<Dictionary<string, object>> UpdateUpload([FromBody] UpdateUploadRequest request)
        {
            var updateUploadDto = _mapper.Map<UpdateUploadRequest, UpdateUploadDto>(request);
            var result = await _UploadService.UpdateUpload(updateUploadDto);
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }
        [HttpPost("DeleteUpload")]
        public async Task<Dictionary<string, object>> DeleteUpload([FromBody] DeleteUploadRequest request)
        {
            var deleteUpload = _mapper.Map<DeleteUploadRequest, DeleteUploadDto>(request);
            var result = await _UploadService.DeleteUpload(deleteUpload);
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }
    }
}
