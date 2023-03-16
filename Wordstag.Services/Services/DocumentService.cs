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
                        where DocumentTB.Document_Id == request.Document_Id
                        select new GetDocumentDto
                        {
                            Document_Id = DocumentTB.Document_Id,
                            Document_Name = DocumentTB.Document_Name,
                            Document_Description = DocumentTB.Document_Description,
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
                            Document_Id = DocumentTB.Document_Id,
                            Document_Name = DocumentTB.Document_Name,
                            Document_Description = DocumentTB.Document_Description,
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
                Document_Id = Guid.NewGuid(),
                Document_Name = request.Document_Name,
                Document_Description = request.Document_Description,
                CreatedBy = request.CreatedBy,
                CreatedOn = DateTime.UtcNow,
            };
            await _readWriteUnitOfWork.DocumentRepository.AddAsync(saveDocument);
            await _readWriteUnitOfWork.CommitAsync();

            return saveDocument.Document_Id;
        }

        public async Task<bool> UpdateDocument(UpdateDocumentDto request)
        {
            var data = await _readWriteUnitOfWork.DocumentRepository.GetFirstOrDefaultAsync(x => x.Document_Id == request.Document_Id);
            if (data != null)
            {
                data.Document_Name = request.Document_Name;
                data.Document_Description = request.Document_Description;
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
