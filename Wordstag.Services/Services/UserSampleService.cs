using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NPOI.OpenXmlFormats.Wordprocessing;
using NPOI.SS.Formula.Functions;
using SixLabors.Fonts.Tables.AdvancedTypographic;
using System.Linq;
using Wordstag.Data.Contexts;
using Wordstag.Data.Infrastructure;
using Wordstag.Domain.Entities.Product;
using Wordstag.Domain.Entities.UserSample;
using Wordstag.Services.Entities;
using Wordstag.Services.Entities.Common;
using Wordstag.Services.Entities.Master;
using Wordstag.Services.Entities.Product;
using Wordstag.Services.Entities.Upload;
using Wordstag.Services.Entities.User;
using Wordstag.Services.Entities.UserSample;
using Wordstag.Services.Infrastructure;
using Wordstag.Services.Interfaces;
using Wordstag.Utility;

namespace Wordstag.Services.Services
{
    public class UserSampleService : IUserSampleService
    {
        private readonly IUnitOfWork<ReadOnlyApplicationDbContext> _readOnlyUnitOfWork;
        private readonly IUnitOfWork<ReadWriteApplicationDbContext> _readWriteUnitOfWork;
        private readonly ReadWriteApplicationDbContext _readWriteUnitOfWorkSP;
        private readonly IUnitOfWork<MasterDbContext> _masterDBContext;
        private readonly IMapper _mapper;

        public UserSampleService(IUnitOfWork<ReadOnlyApplicationDbContext> readOnlyUnitOfWork,
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
        public async Task<List<GetUserSampleDto>> GetUserSample(GetUserSampleDto request)
        {
            var data = (from SampleTB in _readOnlyUnitOfWork.UserSampleRepository.GetAllAsQuerable() 
                        where SampleTB.Id == request.Id
                        select new GetUserSampleDto
                        {
                            Id = SampleTB.Id,
                            LanguageId = SampleTB.LanguageId,
                            UserId = SampleTB.UserId,
                            ProductTypeId = SampleTB.ProductTypeId,
                            UploadId = SampleTB.UploadId,
                            Approve = SampleTB.Approve,
                            ApproveId = SampleTB.ApproveId,
                            CreatedOn = SampleTB.CreatedOn,
                            getLanguageDtos = (from LanguageTB in _readOnlyUnitOfWork.LanguageRepository.GetAllAsQuerable()
                                               where LanguageTB.LanguageId == SampleTB.LanguageId
                                               select new GetLanguageDto
                                               {
                                                   LanguageId = LanguageTB.LanguageId,
                                                   LanguageName = LanguageTB.LanguageName,
                                                   LanguageCode = LanguageTB.LanguageCode
                                               }).ToList(),
                            getUserRegisterDtos = (from userRegisterTB in _readOnlyUnitOfWork.UserRegisterRepository.GetAllAsQuerable()
                                                   where userRegisterTB.IsDeleted != true && userRegisterTB.UserId == SampleTB.UserId
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
                            getUploadDtos = (from UploadTB in _readOnlyUnitOfWork.UploadRepository.GetAllAsQuerable()
                                             where UploadTB.IsDeleted != true && UploadTB.UploadId == SampleTB.UploadId
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
                                             }).ToList(),
                            getProductTypeDtos = (from ProducttypeTB in _readOnlyUnitOfWork.ProductTypeRepository.GetAllAsQuerable()
                                                  where ProducttypeTB.TypeId == SampleTB.ProductTypeId && ProducttypeTB.IsDeleted != true
                                                  select new GetProductTypeDto
                                                  {
                                                      TypeId = ProducttypeTB.TypeId,
                                                      ProductTypeName = ProducttypeTB.ProductTypeName,
                                                      ProductTypeDescription = ProducttypeTB.ProductTypeDescription,
                                                  }).ToList(),
                        }).ToList();
            return data;
        }
        public async Task<GenericList<GetUserSampleDto>> GetAllUserSample(PaginationDto paginationDto)
        {
            var dataQuery = (from SampleTB in _readOnlyUnitOfWork.UserSampleRepository.GetAllAsQuerable()
                        select new GetUserSampleDto
                        {
                            Id = SampleTB.Id,
                            LanguageId = SampleTB.LanguageId,
                            UserId = SampleTB.UserId,
                            ProductTypeId = SampleTB.ProductTypeId,
                            UploadId = SampleTB.UploadId,
                            Approve = SampleTB.Approve,
                            ApproveId = SampleTB.ApproveId,
                            CreatedOn = SampleTB.CreatedOn,
                            getLanguageDtos = (from LanguageTB in _readOnlyUnitOfWork.LanguageRepository.GetAllAsQuerable()
                                               where LanguageTB.LanguageId == SampleTB.LanguageId
                                               select new GetLanguageDto
                                               {
                                                   LanguageId = LanguageTB.LanguageId,
                                                   LanguageName = LanguageTB.LanguageName,
                                                   LanguageCode = LanguageTB.LanguageCode
                                               }).ToList(),
                            getUserRegisterDtos = (from userRegisterTB in _readOnlyUnitOfWork.UserRegisterRepository.GetAllAsQuerable()
                                                   where userRegisterTB.IsDeleted != true && userRegisterTB.UserId == SampleTB.UserId
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
                            getUploadDtos = (from UploadTB in _readOnlyUnitOfWork.UploadRepository.GetAllAsQuerable()
                                             where UploadTB.IsDeleted != true && UploadTB.UploadId == SampleTB.UploadId
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
                                             }).ToList(),
                            getProductTypeDtos = (from ProducttypeTB in _readOnlyUnitOfWork.ProductTypeRepository.GetAllAsQuerable()
                                                  where ProducttypeTB.TypeId == SampleTB.ProductTypeId && ProducttypeTB.IsDeleted != true
                                                  select new GetProductTypeDto
                                                  {
                                                      TypeId = ProducttypeTB.TypeId,
                                                      ProductTypeName = ProducttypeTB.ProductTypeName,
                                                      ProductTypeDescription = ProducttypeTB.ProductTypeDescription,
                                                  }).ToList(),
                        });
            if (!string.IsNullOrEmpty(paginationDto.OrderBy))
            {
                dataQuery = dataQuery.OrderByDynamic(paginationDto.OrderBy, paginationDto.OrderDirection);
            }
            if (!string.IsNullOrEmpty(paginationDto.GlobalSearch))
            {
                dataQuery = dataQuery.Where(x => x.Approve.Contains(paginationDto.GlobalSearch)
                || (x.Approve != null && x.Approve.Contains(paginationDto.GlobalSearch))
                || (GenericMethods.checkStringIsValidDateTime(paginationDto.GlobalSearch) == true && x.CreatedOn == Convert.ToDateTime(paginationDto.GlobalSearch))
                || (GenericMethods.checkStringIsValidDateTime(paginationDto.GlobalSearch) == true && x.UpdatedOn != null && x.UpdatedOn == Convert.ToDateTime(paginationDto.GlobalSearch))
                );
            }

            // Before calculate count if required any filter then apply that first then applied pagination
            var dataCount = dataQuery.Count();
            var data = new GenericList<GetUserSampleDto>();
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
        public async Task<Guid> SaveUserSample(SaveUserSampleDto request)
        {
            var saveSample = new UserSample()
            {
                Id = Guid.NewGuid(),
                LanguageId = request.LanguageId,
                UserId = request.UserId,
                ProductTypeId = request.ProductTypeId,
                UploadId = request.UploadId,
                Approve = request.Approve,
                CreatedBy = request.CreatedBy,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false,
            };
            await _readWriteUnitOfWork.UserSampleRepository.AddAsync(saveSample);
            await _readWriteUnitOfWork.CommitAsync();

            return saveSample.Id;
        }

        public async Task<bool> UpdateUserSample(UpdateUserSampleDto request)
        {
            var data = await _readWriteUnitOfWork.UserSampleRepository.GetFirstOrDefaultAsync(x => x.Id == request.Id);
            if (data != null)
            {
                data.LanguageId = request.LanguageId;
                data.UserId = request.UserId;
                data.UploadId = request.UploadId;
                data.ProductTypeId = request.ProductTypeId;
                data.ApproveId = request.ApproveId;
                data.Approve = request.Approve;
                data.UpdatedBy = request.UpdatedBy;
                data.UpdatedOn = DateTime.UtcNow;
                await _readWriteUnitOfWork.CommitAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteUserSample(DeleteUserSampleDto request)
        {
            var data = await _readWriteUnitOfWork.UserSampleRepository.GetFirstOrDefaultAsync(x => x.Id == request.Id);
            if (data != null)
            {
                data.IsDeleted = true;
                await _readWriteUnitOfWork.CommitAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> SetApprove(ApproveAndUnApproveDto request)
        {
            var data = await _readWriteUnitOfWork.UserSampleRepository.GetFirstOrDefaultAsync(x => x.Id == request.User_SampleID);
            if (data != null)
            {
                data.Approve = request.Approve;
                data.ApproveId = request.Approve_Id;
                await _readWriteUnitOfWork.CommitAsync();
                return true;
            }
            return false;
        }

        public async Task<List<GetUserSampleDto>> SearchApprove(GetUserSampleDto request)
        {
            var data = (from SampleTB in _readOnlyUnitOfWork.UserSampleRepository.GetAllAsQuerable()
                        where SampleTB.Approve == request.Approve
                        select new GetUserSampleDto
                        {
                            Id = SampleTB.Id,
                            LanguageId = SampleTB.LanguageId,
                            UserId = SampleTB.UserId,
                            ProductTypeId = SampleTB.ProductTypeId,
                            UploadId = SampleTB.UploadId,
                            Approve = SampleTB.Approve,
                            ApproveId = SampleTB.ApproveId,
                            CreatedOn = SampleTB.CreatedOn,
                            getLanguageDtos = (from LanguageTB in _readOnlyUnitOfWork.LanguageRepository.GetAllAsQuerable()
                                               where LanguageTB.LanguageId == SampleTB.LanguageId
                                               select new GetLanguageDto
                                               {
                                                   LanguageId = LanguageTB.LanguageId,
                                                   LanguageName = LanguageTB.LanguageName,
                                                   LanguageCode = LanguageTB.LanguageCode
                                               }).ToList(),
                            getUserRegisterDtos = (from userRegisterTB in _readOnlyUnitOfWork.UserRegisterRepository.GetAllAsQuerable()
                                                   where userRegisterTB.IsDeleted != true && userRegisterTB.UserId == SampleTB.UserId
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
                            getUploadDtos = (from UploadTB in _readOnlyUnitOfWork.UploadRepository.GetAllAsQuerable()
                                             where UploadTB.IsDeleted != true && UploadTB.UploadId == SampleTB.UploadId
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
                                             }).ToList(),
                            getProductTypeDtos = (from ProducttypeTB in _readOnlyUnitOfWork.ProductTypeRepository.GetAllAsQuerable()
                                                  where ProducttypeTB.TypeId == SampleTB.ProductTypeId && ProducttypeTB.IsDeleted != true
                                                  select new GetProductTypeDto
                                                  {
                                                      TypeId = ProducttypeTB.TypeId,
                                                      ProductTypeName = ProducttypeTB.ProductTypeName,
                                                      ProductTypeDescription = ProducttypeTB.ProductTypeDescription,
                                                  }).ToList(),
                        }).ToList();
            return data;
        }
    }
}
