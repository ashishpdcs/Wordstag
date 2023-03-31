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
    public class DocumentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDocumentService _DocumentService;
        public DocumentController(IDocumentService DocumentService, IMapper mapper)
        {
            _mapper = mapper;
            _DocumentService = DocumentService;
        }
        [HttpPost("GetDocument")]
        public async Task<Dictionary<string, object>> GetDocument([FromBody] GetDocumentRequest request)
        {
            var userdto = _mapper.Map<GetDocumentRequest, GetDocumentDto>(request);
            var result = await _DocumentService.GetDocument(userdto);
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }
        [HttpPost("GetAllDocument")]
        public async Task<Dictionary<string, object>> GetAllDocument(PaginationDto paginationDto)
        {
            var result = await _DocumentService.GetAllDocument(paginationDto);
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }

        [HttpPost("SaveDocument")]
        public async Task<Dictionary<string, object>> SaveDocument([FromBody] SaveDocumentRequest request)
        {
            var saveDocumentDto = _mapper.Map<SaveDocumentRequest, SaveDocumentDto>(request);
            var result = await _DocumentService.SaveDocument(saveDocumentDto);
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }
        [HttpPost("UpdateDocument")]
        public async Task<Dictionary<string, object>> UpdateDocument([FromBody] UpdateDocumentRequest request)
        {
            var updateDocumentDto = _mapper.Map<UpdateDocumentRequest, UpdateDocumentDto>(request);
            var result = await _DocumentService.UpdateDocument(updateDocumentDto);
            return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        }
        //[HttpPost("DeleteDocument")]
        //public async Task<Dictionary<string, object>> DeleteDocument([FromBody] DeleteDocumentRequest request)
        //{
        //    var deleteDocument = _mapper.Map<DeleteDocumentRequest, DeleteDocumentDto>(request);
        //    var result = await _DocumentService.DeleteDocument(deleteDocument);
        //    return new Dictionary<string, object>() { { Constants.ResponseDataField, result } };
        //}
    }
}
