using AutoMapper;
using Wordstag.Data.Contexts;
using Wordstag.Data.Infrastructure;
using Wordstag.Domain.Entities.Product;
using Wordstag.Services.Entities.Product;
using Wordstag.Services.Interfaces;

namespace Wordstag.Services.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IUnitOfWork<ReadOnlyApplicationDbContext> _readOnlyUnitOfWork;
        private readonly IUnitOfWork<ReadWriteApplicationDbContext> _readWriteUnitOfWork;
        private readonly ReadWriteApplicationDbContext _readWriteUnitOfWorkSP;
        private readonly IUnitOfWork<MasterDbContext> _masterDBContext;
        private readonly IMapper _mapper;
        private readonly IFacebookService _facebookService;

        public DocumentService(IUnitOfWork<ReadOnlyApplicationDbContext> readOnlyUnitOfWork,
             IUnitOfWork<MasterDbContext> masterDBContext, IMapper mapper,
             IUnitOfWork<ReadWriteApplicationDbContext> readWriteUnitOfWork,
             ReadWriteApplicationDbContext readWriteUnitOfWorkSP, IFacebookService facebookService)
        {
            _readOnlyUnitOfWork = readOnlyUnitOfWork;
            _masterDBContext = masterDBContext;
            _readWriteUnitOfWork = readWriteUnitOfWork;
            _mapper = mapper;
            _readWriteUnitOfWorkSP = readWriteUnitOfWorkSP;
            _facebookService = facebookService;
        }
        public async Task<List<GetDocumentDto>> GetDocument(GetDocumentDto request)
        {
            var data = (from DocumentTB in _readOnlyUnitOfWork.DocumentRepository.GetAllAsQuerable()
                        where DocumentTB.DocumentId == request.DocumentId
                        select new GetDocumentDto
                        {
                            DocumentId = DocumentTB.DocumentId,
                            DocumentName = DocumentTB.DocumentName,
                            DocumentDescription = DocumentTB.DocumentDescription,
                            CreatedBy = DocumentTB.CreatedBy,
                            CreatedOn = DocumentTB.CreatedOn, 
                            UpdatedBy = DocumentTB.UpdatedBy,
                            UpdatedOn = DocumentTB.UpdatedOn,
                        }).ToList();
            return data;
        }
        public async Task<List<GetDocumentDto>> GetAllDocument()
        {
            var data = (from DocumentTB in _readOnlyUnitOfWork.DocumentRepository.GetAllAsQuerable()
                        select new GetDocumentDto
                        {
                            DocumentId = DocumentTB.DocumentId,
                            DocumentName = DocumentTB.DocumentName,
                            DocumentDescription = DocumentTB.DocumentDescription,
                            CreatedBy = DocumentTB.CreatedBy,
                            CreatedOn = DocumentTB.CreatedOn,
                            UpdatedBy = DocumentTB.UpdatedBy,
                            UpdatedOn = DocumentTB.UpdatedOn,
                        }).ToList();
            return data;
        }
        public async Task<Guid> SaveDocument(SaveDocumentDto request)
        {
            var saveDocument = new Document()
            {
                DocumentId = Guid.NewGuid(),
                DocumentName = request.DocumentName,
                DocumentDescription = request.DocumentDescription,
                CreatedBy = request.CreatedBy,
                CreatedOn = DateTime.UtcNow,
            };
            await _readWriteUnitOfWork.DocumentRepository.AddAsync(saveDocument);
            await _readWriteUnitOfWork.CommitAsync();

            return saveDocument.DocumentId;
        }

        public async Task<bool> UpdateDocument(UpdateDocumentDto request)
        {
            var data = await _readWriteUnitOfWork.DocumentRepository.GetFirstOrDefaultAsync(x => x.DocumentId == request.DocumentId);
            if (data != null)
            {
                data.DocumentName = request.DocumentName;
                data.DocumentDescription = request.DocumentDescription;
                data.UpdatedBy = request.UpdatedBy;
                data.UpdatedOn = DateTime.UtcNow;
                await _readWriteUnitOfWork.CommitAsync();
                return true;
            }
            return false;
        }

        //public async Task<bool> DeleteDocument(DeleteDocumentDto request)
        //{
        //    var data = await _readWriteUnitOfWork.DocumentRepository.GetFirstOrDefaultAsync(x => x.Document_Id == request.Document_Id);
        //    if (data != null)
        //    {
        //        data.IsDeleted = true;
        //        await _readWriteUnitOfWork.CommitAsync();
        //        return true;
        //    }
        //    return false;
        //}

    }
}
