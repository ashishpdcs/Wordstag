using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NPOI.OpenXmlFormats.Wordprocessing;
using NPOI.SS.Formula.Functions;
using SixLabors.Fonts.Tables.AdvancedTypographic;
using Wordstag.Data.Contexts;
using Wordstag.Data.Infrastructure;
using Wordstag.Domain.Entities.Product;
using Wordstag.Domain.Entities.UserSample;
using Wordstag.Services.Entities.Master;
using Wordstag.Services.Entities.Product;
using Wordstag.Services.Entities.Upload;
using Wordstag.Services.Entities.User;
using Wordstag.Services.Entities.UserSample;
using Wordstag.Services.Interfaces;

namespace Wordstag.Services.Services
{
    public class UserSampleService : IUserSampleService
    {
        private readonly IUnitOfWork<ReadOnlyApplicationDbContext> _readOnlyUnitOfWork;
        private readonly IUnitOfWork<ReadWriteApplicationDbContext> _readWriteUnitOfWork;
        private readonly ReadWriteApplicationDbContext _readWriteUnitOfWorkSP;
        private readonly IUnitOfWork<MasterDbContext> _masterDBContext;
        private readonly IMapper _mapper;
        private readonly IFacebookService _facebookService;

        public UserSampleService(IUnitOfWork<ReadOnlyApplicationDbContext> readOnlyUnitOfWork,
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
        public async Task<List<GetUserSampleDto>> GetAllUserSample()
        {
            var data = (from SampleTB in _readOnlyUnitOfWork.UserSampleRepository.GetAllAsQuerable()
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
    }
}
