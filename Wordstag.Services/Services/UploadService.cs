using AutoMapper;
using NPOI.HPSF;
using System.Drawing.Imaging;
using System.Linq;
using Wordstag.Data.Contexts;
using Wordstag.Data.Infrastructure;
using Wordstag.Domain.Entities.Upload;
using Wordstag.Services.Entities;
using Wordstag.Services.Entities.Common;
using Wordstag.Services.Entities.Product;
using Wordstag.Services.Entities.Upload;
using Wordstag.Services.Entities.User;
using Wordstag.Services.Infrastructure;
using Wordstag.Services.Interfaces;
using Wordstag.Utility;

namespace Wordstag.Services.Services
{
    public class UploadService : IUploadService
    {
        private readonly IUnitOfWork<ReadOnlyApplicationDbContext> _readOnlyUnitOfWork;
        private readonly IUnitOfWork<ReadWriteApplicationDbContext> _readWriteUnitOfWork;
        private readonly ReadWriteApplicationDbContext _readWriteUnitOfWorkSP;
        private readonly IUnitOfWork<MasterDbContext> _masterDBContext;
        private readonly IMapper _mapper;

        public UploadService(IUnitOfWork<ReadOnlyApplicationDbContext> readOnlyUnitOfWork,
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
                            FileName = UploadTB.FileName,
                            FileType = UploadTB.FileType,
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
        public async Task<GenericList<GetUploadDto>> GetAllUpload(PaginationDto paginationDto)
        {
            var dataQuery = (from UploadTB in _readOnlyUnitOfWork.UploadRepository.GetAllAsQuerable()
                        where UploadTB.IsDeleted != true
                        select new GetUploadDto
                        {
                            UploadId = UploadTB.UploadId,
                            ProductId = UploadTB.ProductId,
                            LanguageId = UploadTB.LanguageId,
                            UserId = UploadTB.UserId,
                            FileName = UploadTB.FileName,
                            FileType = UploadTB.FileType,
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
                        });
            if (!string.IsNullOrEmpty(paginationDto.OrderBy))
            {
                dataQuery = dataQuery.OrderByDynamic(paginationDto.OrderBy, paginationDto.OrderDirection);
            }
            if (!string.IsNullOrEmpty(paginationDto.GlobalSearch))
            {
                dataQuery = dataQuery.Where(x => x.OrignalFile.Contains(paginationDto.GlobalSearch)
                || (x.OrignalFile != null && x.OrignalFile.Contains(paginationDto.GlobalSearch))
                || (GenericMethods.checkStringIsValidDateTime(paginationDto.GlobalSearch) == true && x.CreatedOn == Convert.ToDateTime(paginationDto.GlobalSearch))
                || (GenericMethods.checkStringIsValidDateTime(paginationDto.GlobalSearch) == true && x.UpdatedOn != null && x.UpdatedOn == Convert.ToDateTime(paginationDto.GlobalSearch))
                );
            }

            // Before calculate count if required any filter then apply that first then applied pagination
            var dataCount = dataQuery.Count();
            var data = new GenericList<GetUploadDto>();
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
        public async Task<Guid> SaveUpload(SaveUploadDto request)
        {
            var saveUpload = new UploadTbl()
            {
                UploadId = Guid.NewGuid(),
                ProductId = request.ProductId,
                LanguageId = request.LanguageId,
                UserId = request.UserId,
                FileName = request.FileName,
                FileType = request.FileType,
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
                data.FileName = request.FileName;
                data.FileType = request.FileType;
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
