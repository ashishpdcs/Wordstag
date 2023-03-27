using AutoMapper;
using Wordstag.Data.Contexts;
using Wordstag.Data.Infrastructure;
using Wordstag.Domain.Entities.Upload;
using Wordstag.Services.Entities.Product;
using Wordstag.Services.Entities.Upload;
using Wordstag.Services.Entities.User;
using Wordstag.Services.Interfaces;

namespace Wordstag.Services.Services
{
    public class UploadService : IUploadService
    {
        private readonly IUnitOfWork<ReadOnlyApplicationDbContext> _readOnlyUnitOfWork;
        private readonly IUnitOfWork<ReadWriteApplicationDbContext> _readWriteUnitOfWork;
        private readonly ReadWriteApplicationDbContext _readWriteUnitOfWorkSP;
        private readonly IUnitOfWork<MasterDbContext> _masterDBContext;
        private readonly IMapper _mapper;
        private readonly IFacebookService _facebookService;

        public UploadService(IUnitOfWork<ReadOnlyApplicationDbContext> readOnlyUnitOfWork,
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
        public async Task<List<GetUploadDto>> GetUpload(GetUploadDto request)
        {
            var data = (from UploadTB in _readOnlyUnitOfWork.UploadRepository.GetAllAsQuerable()
                        where UploadTB.UploadId == request.UploadId && UploadTB.IsDeleted != true
                        select new GetUploadDto
                        {
                            UploadId = UploadTB.UploadId,
                            ProductId = UploadTB.ProductId,
                            LanguageId = UploadTB.LanguageId,
                            UserId = UploadTB.UserId,
                            OrignalFile = UploadTB.OrignalFile,
                            UpdatedFile = UploadTB.UpdatedFile,
                            FilePath = UploadTB.FilePath,
                            FileSize = UploadTB.FileSize,
                            CreatedBy = UploadTB.CreatedBy,
                            CreatedOn = UploadTB.CreatedOn,
                            UpdatedBy = UploadTB.UpdatedBy,
                            UpdatedOn = UploadTB.UpdatedOn,
                            IsDeleted = UploadTB.IsDeleted,
                            productDto = (from producttbl in _readOnlyUnitOfWork.ProductRepository.GetAllAsQuerable()
                                          where producttbl.IsDeleted != true && producttbl.ProductId == UploadTB.ProductId
                                          select new GetProductDto
                                          {
                                              ProductId = producttbl.ProductId,
                                              ProductName = producttbl.ProductName,
                                              Description = producttbl.Description,
                                              Price = producttbl.Price,
                                              ProductTypeId = producttbl.ProductTypeId,
                                              FromLanguage = producttbl.FromLanguage,
                                              ToLanguage = producttbl.ToLanguage
                                          }).ToList(),
                            LanguageDtos = (from LanguageTB in _readOnlyUnitOfWork.LanguageRepository.GetAllAsQuerable()
                                            where LanguageTB.LanguageId == UploadTB.LanguageId
                                            select new GetLanguageDto
                                            {
                                                LanguageId = LanguageTB.LanguageId,
                                                LanguageName = LanguageTB.LanguageName,
                                                LanguageCode = LanguageTB.LanguageCode
                                            }).ToList(),
                            userRegisters = (from userRegisterTB in _readOnlyUnitOfWork.UserRegisterRepository.GetAllAsQuerable()
                                             where userRegisterTB.IsDeleted != true && userRegisterTB.UserId == UploadTB.UserId
                                             select new GetUserRegisterDto
                                             {
                                                 UserId = userRegisterTB.UserId,
                                                 FirstName = userRegisterTB.FirstName,
                                                 LastName = userRegisterTB.LastName,
                                                 Password = userRegisterTB.Password,
                                                 EmailAddress = userRegisterTB.EmailAddress,
                                                 MobileNo = userRegisterTB.MobileNo,
                                                 Gender = userRegisterTB.Gender,
                                                 UserType = userRegisterTB.UserType,
                                             }).ToList(),
                        }).ToList();
            return data;
        }
        public async Task<List<GetUploadDto>> GetAllUpload()
        {
            var data = (from UploadTB in _readOnlyUnitOfWork.UploadRepository.GetAllAsQuerable()
                        where UploadTB.IsDeleted != true
                        select new GetUploadDto
                        {
                            UploadId = UploadTB.UploadId,
                            ProductId = UploadTB.ProductId,
                            LanguageId = UploadTB.LanguageId,
                            UserId = UploadTB.UserId,
                            OrignalFile = UploadTB.OrignalFile,
                            UpdatedFile = UploadTB.UpdatedFile,
                            FilePath = UploadTB.FilePath,
                            FileSize = UploadTB.FileSize,
                            CreatedBy = UploadTB.CreatedBy,
                            CreatedOn = UploadTB.CreatedOn,
                            UpdatedBy = UploadTB.UpdatedBy,
                            UpdatedOn = UploadTB.UpdatedOn,
                            IsDeleted = UploadTB.IsDeleted,
                            productDto = (from producttbl in _readOnlyUnitOfWork.ProductRepository.GetAllAsQuerable()
                                          where producttbl.IsDeleted != true && producttbl.ProductId == UploadTB.ProductId
                                          select new GetProductDto
                                          {
                                              ProductId = producttbl.ProductId,
                                              ProductName = producttbl.ProductName,
                                              Description = producttbl.Description,
                                              Price = producttbl.Price,
                                              ProductTypeId = producttbl.ProductTypeId,
                                              FromLanguage = producttbl.FromLanguage,
                                              ToLanguage = producttbl.ToLanguage
                                          }).ToList(),
                            LanguageDtos = (from LanguageTB in _readOnlyUnitOfWork.LanguageRepository.GetAllAsQuerable()
                                            where LanguageTB.LanguageId == UploadTB.LanguageId
                                            select new GetLanguageDto
                                            {
                                                LanguageId = LanguageTB.LanguageId,
                                                LanguageName = LanguageTB.LanguageName,
                                                LanguageCode = LanguageTB.LanguageCode
                                            }).ToList(),
                            userRegisters = (from userRegisterTB in _readOnlyUnitOfWork.UserRegisterRepository.GetAllAsQuerable()
                                             where userRegisterTB.IsDeleted != true && userRegisterTB.UserId == UploadTB.UserId
                                             select new GetUserRegisterDto
                                             {
                                                 UserId = userRegisterTB.UserId,
                                                 FirstName = userRegisterTB.FirstName,
                                                 LastName = userRegisterTB.LastName,
                                                 Password = userRegisterTB.Password,
                                                 EmailAddress = userRegisterTB.EmailAddress,
                                                 MobileNo = userRegisterTB.MobileNo,
                                                 Gender = userRegisterTB.Gender,
                                                 UserType = userRegisterTB.UserType,
                                             }).ToList(),
                        }).ToList();
            return data;
        }
        public async Task<Guid> SaveUpload(SaveUploadDto request)
        {
            var saveUpload = new UploadTbl()
            {
                UploadId = Guid.NewGuid(),
                ProductId = request.ProductId,
                LanguageId = request.LanguageId,
                UserId = request.UserId,
                OrignalFile = request.OrignalFile,
                FilePath = request.FilePath,
                FileSize = request.FileSize,
                CreatedBy = request.CreatedBy,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false,
            };
            await _readWriteUnitOfWork.UploadRepository.AddAsync(saveUpload);
            await _readWriteUnitOfWork.CommitAsync();

            return saveUpload.UploadId;
        }

        public async Task<bool> UpdateUpload(UpdateUploadDto request)
        {
            var data = await _readWriteUnitOfWork.UploadRepository.GetFirstOrDefaultAsync(x => x.UploadId == request.UploadId);
            if (data != null)
            {
                data.ProductId = request.ProductId; ;
                data.LanguageId = request.LanguageId;
                data.UserId = request.UserId;
                data.UpdatedFile = request.UpdatedFile;
                data.FilePath = request.FilePath;
                data.FileSize = request.FileSize;
                data.UpdatedBy = request.UpdatedBy;
                data.UpdatedOn = DateTime.UtcNow;
                await _readWriteUnitOfWork.CommitAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteUpload(DeleteUploadDto request)
        {
            var data = await _readWriteUnitOfWork.UploadRepository.GetFirstOrDefaultAsync(x => x.UploadId == request.UploadId);
            if (data != null)
            {
                data.IsDeleted = true;
                await _readWriteUnitOfWork.CommitAsync();
                return true;
            }
            return false;
        }
    }
}
