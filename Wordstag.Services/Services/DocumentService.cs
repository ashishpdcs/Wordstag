using AutoMapper;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Linq;
using Wordstag.Data.Contexts;
using Wordstag.Data.Infrastructure;
using Wordstag.Domain.Entities.Product;
using Wordstag.Services.Entities;
using Wordstag.Services.Entities.Common;
using Wordstag.Services.Entities.Product;
using Wordstag.Services.Infrastructure;
using Wordstag.Services.Interfaces;
using Wordstag.Utility;

namespace Wordstag.Services.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IUnitOfWork<ReadOnlyApplicationDbContext> _readOnlyUnitOfWork;
        private readonly IUnitOfWork<ReadWriteApplicationDbContext> _readWriteUnitOfWork;
        private readonly ReadWriteApplicationDbContext _readWriteUnitOfWorkSP;
        private readonly IUnitOfWork<MasterDbContext> _masterDBContext;
        private readonly IMapper _mapper;

        public DocumentService(IUnitOfWork<ReadOnlyApplicationDbContext> readOnlyUnitOfWork,
             IUnitOfWork<MasterDbContext> masterDBContext, IMapper mapper,
             IUnitOfWork<ReadWriteApplicationDbContext> readWriteUnitOfWork,
             ReadWriteApplicationDbContext readWriteUnitOfWorkSP)
        {
            _readOnlyUnitOfWork = readOnlyUnitOfWork;
            _masterDBContext = masterDBContext;
            _readWriteUnitOfWork = readWriteUnitOfWork;
            _mapper = mapper;
            _readWriteUnitOfWorkSP = readWriteUnitOfWorkSP;
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
        public async Task<GenericList<GetDocumentDto>> GetAllDocument(PaginationDto paginationDto)
        {
            var dataQuery = (from DocumentTB in _readOnlyUnitOfWork.DocumentRepository.GetAllAsQuerable()
                        select new GetDocumentDto
                        {
                            DocumentId = DocumentTB.DocumentId,
                            DocumentName = DocumentTB.DocumentName,
                            DocumentDescription = DocumentTB.DocumentDescription,
                            CreatedBy = DocumentTB.CreatedBy,
                            CreatedOn = DocumentTB.CreatedOn,
                            UpdatedBy = DocumentTB.UpdatedBy,
                            UpdatedOn = DocumentTB.UpdatedOn,
                        });
            if (!string.IsNullOrEmpty(paginationDto.OrderBy))
            {
                dataQuery = dataQuery.OrderByDynamic(paginationDto.OrderBy, paginationDto.OrderDirection);
            }
            if (!string.IsNullOrEmpty(paginationDto.GlobalSearch))
            {
                dataQuery = dataQuery.Where(x => x.DocumentName.Contains(paginationDto.GlobalSearch)
                || (x.DocumentName != null && x.DocumentName.Contains(paginationDto.GlobalSearch))
                || (GenericMethods.checkStringIsValidDateTime(paginationDto.GlobalSearch) == true && x.CreatedOn == Convert.ToDateTime(paginationDto.GlobalSearch))
                || (GenericMethods.checkStringIsValidDateTime(paginationDto.GlobalSearch) == true && x.UpdatedOn != null && x.UpdatedOn == Convert.ToDateTime(paginationDto.GlobalSearch))
                );
            }

            // Before calculate count if required any filter then apply that first then applied pagination
            var dataCount = dataQuery.Count();
            var data = new GenericList<GetDocumentDto>();
            data.List = paginationDto.PageIndex == 0 ? dataQuery.ToList() : dataQuery.Skip(((paginationDto.PageIndex.Value - 1) * paginationDto.PageSize.Value)).Take(paginationDto.PageSize.Value).ToList();
            data.TotalCount = dataCount;
            data.PageCount = dataCount;
            if (paginationDto.PageSize != null && paginationDto.PageSize != 0)
            {
                if (data.TotalCount % paginationDto.PageSize.Value == 0)
                {
                    data.PageCount = data.TotalCount / paginationDto.PageSize.Value;
                }
                else
                {
                    data.PageCount = (data.TotalCount / paginationDto.PageSize.Value) + 1;
                }
            }
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
