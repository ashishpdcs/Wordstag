using AutoMapper;
using Wordstag.Data.Contexts;
using Wordstag.Data.Infrastructure;
using Wordstag.Domain.Entities.Product;
using Wordstag.Services.Entities.Product;
using Wordstag.Services.Interfaces;

namespace Wordstag.Services.Services
{
    public class LanguageService : ILanguageService
    {
        private readonly IUnitOfWork<ReadOnlyApplicationDbContext> _readOnlyUnitOfWork;
        private readonly IUnitOfWork<ReadWriteApplicationDbContext> _readWriteUnitOfWork;
        private readonly ReadWriteApplicationDbContext _readWriteUnitOfWorkSP;
        private readonly IUnitOfWork<MasterDbContext> _masterDBContext;
        private readonly IMapper _mapper;

        public LanguageService(IUnitOfWork<ReadOnlyApplicationDbContext> readOnlyUnitOfWork,
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
        public async Task<List<GetLanguageDto>> GetLanguage(GetLanguageDto request)
        {
            var data = (from LanguageTB in _readOnlyUnitOfWork.LanguageRepository.GetAllAsQuerable()
                        where LanguageTB.LanguageId == request.LanguageId
                        select new GetLanguageDto
                        {
                            LanguageId = LanguageTB.LanguageId,
                            LanguageName = LanguageTB.LanguageName,
                            LanguageCode = LanguageTB.LanguageCode,
                            CreatedBy = LanguageTB.CreatedBy,
                            CreatedOn = LanguageTB.CreatedOn, 
                            UpdatedBy = LanguageTB.UpdatedBy,
                            UpdatedOn = LanguageTB.UpdatedOn,
                        }).ToList();
            return data;
        }
        public async Task<List<GetLanguageDto>> GetAllLanguage()
        {
            var data = (from LanguageTB in _readOnlyUnitOfWork.LanguageRepository.GetAllAsQuerable()
                        select new GetLanguageDto
                        {
                            LanguageId = LanguageTB.LanguageId,
                            LanguageName = LanguageTB.LanguageName,
                            LanguageCode = LanguageTB.LanguageCode,
                            CreatedBy = LanguageTB.CreatedBy,
                            CreatedOn = LanguageTB.CreatedOn,
                            UpdatedBy = LanguageTB.UpdatedBy,
                            UpdatedOn = LanguageTB.UpdatedOn,
                        }).ToList();
            return data;
        }
        public async Task<Guid> SaveLanguage(SaveLanguageDto request)
        {
            var saveLanguage = new Language()
            {
                LanguageId = Guid.NewGuid(),
                LanguageName = request.LanguageName,
                LanguageCode = request.LanguageCode,
                CreatedBy = request.CreatedBy,
                CreatedOn = DateTime.UtcNow
            };
            await _readWriteUnitOfWork.LanguageRepository.AddAsync(saveLanguage);
            await _readWriteUnitOfWork.CommitAsync();

            return saveLanguage.LanguageId;
        }

        public async Task<bool> UpdateLanguage(UpdateLanguageDto request)
        {
            var data = await _readWriteUnitOfWork.LanguageRepository.GetFirstOrDefaultAsync(x => x.LanguageId == request.LanguageId);
            if (data != null)
            {
                data.LanguageName = request.LanguageName;
                data.LanguageCode = request.LanguageCode;
                data.UpdatedBy = request.UpdatedBy;
                data.UpdatedOn = DateTime.UtcNow;
                await _readWriteUnitOfWork.CommitAsync();
                return true;
            }
            return false;
        }

        //public async Task<bool> DeleteLanguage(DeleteLanguageDto request)
        //{
        //    var data = await _readWriteUnitOfWork.LanguageRepository.GetFirstOrDefaultAsync(x => x.LanguageId == request.LanguageId);
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
