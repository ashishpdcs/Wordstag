using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NPOI.OpenXmlFormats.Wordprocessing;
using NPOI.SS.Formula.Functions;
using Wordstag.Data.Contexts;
using Wordstag.Data.Infrastructure;
using Wordstag.Domain.Entities.Upload;
using Wordstag.Domain.Entities.User;
using Wordstag.Services.Entities.Upload;
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
                        where UploadTB.Upload_Id == request.Upload_Id && UploadTB.IsDeleted != true
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
                            CreatedBy = UploadTB.CreatedBy,
                            CreatedOn = UploadTB.CreatedOn,
                            UpdatedBy = UploadTB.UpdatedBy,
                            UpdatedOn = UploadTB.UpdatedOn,
                            IsDeleted = UploadTB.IsDeleted,
                        }).ToList();
            return data;
        }
        public async Task<List<GetUploadDto>> GetAllUpload()
        {
            var data = (from UploadTB in _readOnlyUnitOfWork.UploadRepository.GetAllAsQuerable()
                        where UploadTB.IsDeleted != true
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
                            CreatedBy = UploadTB.CreatedBy,
                            CreatedOn = UploadTB.CreatedOn,
                            UpdatedBy = UploadTB.UpdatedBy,
                            UpdatedOn = UploadTB.UpdatedOn,
                            IsDeleted = UploadTB.IsDeleted,
                        }).ToList();
            return data;
        }
        public async Task<Guid> SaveUpload(SaveUploadDto request)
        {
            var saveUpload = new UploadTbl()
            {
                Upload_Id = Guid.NewGuid(),
                Product_Id = request.Product_Id,
                Language_Id = request.Language_Id,
                User_Id = request.User_Id,
                Orignal_File = request.Orignal_File,
                File_Path = request.File_Path,
                File_Size = request.File_Size,
                CreatedBy = request.CreatedBy,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false,
            };
            await _readWriteUnitOfWork.UploadRepository.AddAsync(saveUpload);
            await _readWriteUnitOfWork.CommitAsync();

            return saveUpload.Upload_Id;
        }

        public async Task<bool> UpdateUpload(UpdateUploadDto request)
        {
            var data = await _readWriteUnitOfWork.UploadRepository.GetFirstOrDefaultAsync(x => x.Upload_Id == request.Upload_Id);
            if (data != null)
            {
                data.Product_Id = request.Product_Id; ;
                data.Language_Id = request.Language_Id;
                data.User_Id = request.User_Id;
                data.Updated_File = request.Updated_File;
                data.File_Path = request.File_Path;
                data.File_Size = request.File_Size;
                data.UpdatedBy = request.UpdatedBy;
                data.UpdatedOn = DateTime.UtcNow;
                await _readWriteUnitOfWork.CommitAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteUpload(DeleteUploadDto request)
        {
            var data = await _readWriteUnitOfWork.UploadRepository.GetFirstOrDefaultAsync(x => x.Upload_Id == request.Upload_Id);
            if (data != null)
            {
                data.IsDeleted = true;
                await _readWriteUnitOfWork.CommitAsync();
                return true;
            }
            return false;
        }

        public async Task<List<GetUploadDto>> GetUserUpload(Guid request)
        {
            var data = (from UploadTB in _readOnlyUnitOfWork.UploadRepository.GetAllAsQuerable()
                        where UploadTB.User_Id == request && UploadTB.IsDeleted != true
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
                            CreatedBy = UploadTB.CreatedBy,
                            CreatedOn = UploadTB.CreatedOn,
                            UpdatedBy = UploadTB.UpdatedBy,
                            UpdatedOn = UploadTB.UpdatedOn,
                            IsDeleted = UploadTB.IsDeleted,
                        }).ToList();
            return data;
        }
    }
}
