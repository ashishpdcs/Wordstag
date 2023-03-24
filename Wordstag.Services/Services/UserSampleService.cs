using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NPOI.OpenXmlFormats.Wordprocessing;
using NPOI.SS.Formula.Functions;
using SixLabors.Fonts.Tables.AdvancedTypographic;
using Wordstag.Data.Contexts;
using Wordstag.Data.Infrastructure;
using Wordstag.Domain.Entities.Product;
using Wordstag.Domain.Entities.UserSample;
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
                            Language_Id = SampleTB.Language_Id,
                            User_Id = SampleTB.User_Id,
                            Product_TypeId = SampleTB.Product_TypeId,
                            Upload_Id = SampleTB.Upload_Id,
                            Approve = SampleTB.Approve,
                            Approve_Id = SampleTB.Approve_Id,
                            CreatedOn = SampleTB.CreatedOn,
                            getLanguageDtos = (from LanguageTB in _readOnlyUnitOfWork.LanguageRepository.GetAllAsQuerable()
                                               where LanguageTB.LanguageId == SampleTB.Language_Id
                                               select new GetLanguageDto
                                               {
                                                   LanguageId = LanguageTB.LanguageId,
                                                   Language_Name = LanguageTB.Language_Name,
                                                   Language_Code = LanguageTB.Language_Code
                                               }).ToList(),
                            getUserRegisterDtos = (from userRegisterTB in _readOnlyUnitOfWork.UserRegisterRepository.GetAllAsQuerable()
                                                   where userRegisterTB.IsDeleted != true && userRegisterTB.User_Id == SampleTB.User_Id
                                                   select new GetUserRegisterDto
                                                   {
                                                       User_Id = userRegisterTB.User_Id,
                                                       FirstName = userRegisterTB.FirstName,
                                                       LastName = userRegisterTB.LastName,
                                                       Password = userRegisterTB.Password,
                                                       EmailAddress = userRegisterTB.EmailAddress,
                                                       MobileNo = userRegisterTB.MobileNo,
                                                       Gender = userRegisterTB.Gender,
                                                       UserType = userRegisterTB.UserType,
                                                   }).ToList(),
                            getUploadDtos = (from UploadTB in _readOnlyUnitOfWork.UploadRepository.GetAllAsQuerable()
                                             where UploadTB.IsDeleted != true && UploadTB.Upload_Id == SampleTB.Upload_Id
                                             select new GetUploadDto
                                             {
                                                 Upload_Id = UploadTB.Upload_Id,
                                                 Product_Id = UploadTB.Product_Id,
                                                 Language_Id = UploadTB.Language_Id,
                                                 User_Id = UploadTB.User_Id,
                                                 Orignal_File = UploadTB.Orignal_File,
                                                 Updated_File = UploadTB.Updated_File,
                                                 File_Path = UploadTB.File_Path,
                                                 File_Size = UploadTB.File_Size,
                                             }).ToList(),
                            getProductTypeDtos = (from ProducttypeTB in _readOnlyUnitOfWork.ProductTypeRepository.GetAllAsQuerable()
                                                  where ProducttypeTB.TypeId == SampleTB.Product_TypeId && ProducttypeTB.IsDeleted != true
                                                  select new GetProductTypeDto
                                                  {
                                                      TypeId = ProducttypeTB.TypeId,
                                                      ProductType_Name = ProducttypeTB.ProductType_Name,
                                                      ProductType_Description = ProducttypeTB.ProductType_Description,
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
                            Language_Id = SampleTB.Language_Id,
                            User_Id = SampleTB.User_Id,
                            Product_TypeId = SampleTB.Product_TypeId,
                            Upload_Id = SampleTB.Upload_Id,
                            Approve = SampleTB.Approve,
                            Approve_Id = SampleTB.Approve_Id,
                            CreatedOn = SampleTB.CreatedOn,
                            getLanguageDtos = (from LanguageTB in _readOnlyUnitOfWork.LanguageRepository.GetAllAsQuerable()
                                               where LanguageTB.LanguageId == SampleTB.Language_Id
                                               select new GetLanguageDto
                                               {
                                                   LanguageId = LanguageTB.LanguageId,
                                                   Language_Name = LanguageTB.Language_Name,
                                                   Language_Code = LanguageTB.Language_Code
                                               }).ToList(),
                            getUserRegisterDtos = (from userRegisterTB in _readOnlyUnitOfWork.UserRegisterRepository.GetAllAsQuerable()
                                                   where userRegisterTB.IsDeleted != true && userRegisterTB.User_Id == SampleTB.User_Id
                                                   select new GetUserRegisterDto
                                                   {
                                                       User_Id = userRegisterTB.User_Id,
                                                       FirstName = userRegisterTB.FirstName,
                                                       LastName = userRegisterTB.LastName,
                                                       Password = userRegisterTB.Password,
                                                       EmailAddress = userRegisterTB.EmailAddress,
                                                       MobileNo = userRegisterTB.MobileNo,
                                                       Gender = userRegisterTB.Gender,
                                                       UserType = userRegisterTB.UserType,
                                                   }).ToList(),
                            getUploadDtos = (from UploadTB in _readOnlyUnitOfWork.UploadRepository.GetAllAsQuerable()
                                             where UploadTB.IsDeleted != true && UploadTB.Upload_Id == SampleTB.Upload_Id
                                             select new GetUploadDto
                                             {
                                                 Upload_Id = UploadTB.Upload_Id,
                                                 Product_Id = UploadTB.Product_Id,
                                                 Language_Id = UploadTB.Language_Id,
                                                 User_Id = UploadTB.User_Id,
                                                 Orignal_File = UploadTB.Orignal_File,
                                                 Updated_File = UploadTB.Updated_File,
                                                 File_Path = UploadTB.File_Path,
                                                 File_Size = UploadTB.File_Size,
                                             }).ToList(),
                            getProductTypeDtos = (from ProducttypeTB in _readOnlyUnitOfWork.ProductTypeRepository.GetAllAsQuerable()
                                                  where ProducttypeTB.TypeId == SampleTB.Product_TypeId && ProducttypeTB.IsDeleted != true
                                                  select new GetProductTypeDto
                                                  {
                                                      TypeId = ProducttypeTB.TypeId,
                                                      ProductType_Name = ProducttypeTB.ProductType_Name,
                                                      ProductType_Description = ProducttypeTB.ProductType_Description,
                                                  }).ToList(),
                        }).ToList();
            return data;
        }
        public async Task<Guid> SaveUserSample(SaveUserSampleDto request)
        {
            var saveSample = new UserSample()
            {
                Id = Guid.NewGuid(),
                Language_Id = request.Language_Id,
                User_Id = request.User_Id,
                Product_TypeId = request.Product_TypeId,
                Upload_Id = request.Upload_Id,
                Approve = request.Approve,
                Approve_Id = request.Approve_Id,
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
                data.Language_Id = request.Language_Id;
                data.User_Id = request.User_Id;
                data.Upload_Id = request.Upload_Id;
                data.Product_TypeId = request.Product_TypeId;
                data.Approve_Id = request.Approve_Id;
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

    }
}
