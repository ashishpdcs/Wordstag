using AutoMapper;
using MailKit.Search;
using NPOI.OpenXmlFormats.Wordprocessing;
using NPOI.SS.Formula.Functions;
using Wordstag.Data.Contexts;
using Wordstag.Data.Infrastructure;
using Wordstag.Domain.Entities.Order;
using Wordstag.Domain.Entities.Product;
using Wordstag.Domain.Entities.Upload;
using Wordstag.Services.Entities.Order;
using Wordstag.Services.Entities.Product;
using Wordstag.Services.Entities.Upload;
using Wordstag.Services.Entities.User;
using Wordstag.Services.Interfaces;

namespace Wordstag.Services.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork<ReadOnlyApplicationDbContext> _readOnlyUnitOfWork;
        private readonly IUnitOfWork<ReadWriteApplicationDbContext> _readWriteUnitOfWork;
        private readonly ReadWriteApplicationDbContext _readWriteUnitOfWorkSP;
        private readonly IUnitOfWork<MasterDbContext> _masterDBContext;
        private readonly IMapper _mapper;
        public OrderService(IUnitOfWork<ReadOnlyApplicationDbContext> readOnlyUnitOfWork,
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
        public async Task<List<GetOrderDto>> GetOrder(GetOrderDto request)
        {
            var data = (from OrderTB in _readOnlyUnitOfWork.OrderRepository.GetAllAsQuerable()
                        where OrderTB.OrderId == request.OrderId && OrderTB.IsDeleted != true
                        select new GetOrderDto
                        {
                            OrderId = OrderTB.OrderId,
                            ProductId = OrderTB.ProductId,
                            LanguageId = OrderTB.LanguageId,
                            UserId = OrderTB.UserId,
                            UploadId = OrderTB.UploadId,
                            SampleId = OrderTB.SampleId,
                            CreatedBy = OrderTB.CreatedBy,
                            CreatedOn = OrderTB.CreatedOn,
                            UpdatedBy = OrderTB.UpdatedBy,
                            UpdatedOn = OrderTB.UpdatedOn,
                            IsDeleted = OrderTB.IsDeleted,
                            productDtos = (from producttbl in _readOnlyUnitOfWork.ProductRepository.GetAllAsQuerable()
                                           where producttbl.IsDeleted != true && producttbl.ProductId == OrderTB.ProductId
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
                                            where LanguageTB.LanguageId == OrderTB.LanguageId
                                            select new GetLanguageDto
                                            {
                                                LanguageId = LanguageTB.LanguageId,
                                                LanguageName = LanguageTB.LanguageName,
                                                LanguageCode = LanguageTB.LanguageCode
                                            }).ToList(),
                            UserRegisterDtos = (from userRegisterTB in _readOnlyUnitOfWork.UserRegisterRepository.GetAllAsQuerable()
                                                where userRegisterTB.IsDeleted != true && userRegisterTB.UserId == OrderTB.UserId
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
                            UploadDtos = (from UploadTB in _readOnlyUnitOfWork.UploadRepository.GetAllAsQuerable()
                                          where UploadTB.IsDeleted != true && UploadTB.UploadId == OrderTB.UploadId
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
                                          }).ToList()
                        }).ToList();
            return data;
        }
        public async Task<List<GetOrderDto>> GetAllOrder()
        {
            var data = (from OrderTB in _readOnlyUnitOfWork.OrderRepository.GetAllAsQuerable()
                        where OrderTB.IsDeleted != true
                        select new GetOrderDto
                        {
                            OrderId = OrderTB.OrderId,
                            ProductId = OrderTB.ProductId,
                            LanguageId = OrderTB.LanguageId,
                            UserId = OrderTB.UserId,
                            UploadId = OrderTB.UploadId,
                            SampleId = OrderTB.SampleId,
                            CreatedBy = OrderTB.CreatedBy,
                            CreatedOn = OrderTB.CreatedOn,
                            UpdatedBy = OrderTB.UpdatedBy,
                            UpdatedOn = OrderTB.UpdatedOn,
                            IsDeleted = OrderTB.IsDeleted,
                            productDtos = (from producttbl in _readOnlyUnitOfWork.ProductRepository.GetAllAsQuerable()
                                           where producttbl.IsDeleted != true && producttbl.ProductId == OrderTB.ProductId
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
                                            where LanguageTB.LanguageId == OrderTB.LanguageId
                                            select new GetLanguageDto
                                            {
                                                LanguageId = LanguageTB.LanguageId,
                                                LanguageName = LanguageTB.LanguageName,
                                                LanguageCode = LanguageTB.LanguageCode
                                            }).ToList(),
                            UserRegisterDtos = (from userRegisterTB in _readOnlyUnitOfWork.UserRegisterRepository.GetAllAsQuerable()
                                                where userRegisterTB.IsDeleted != true && userRegisterTB.UserId == OrderTB.UserId
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
                            UploadDtos = (from UploadTB in _readOnlyUnitOfWork.UploadRepository.GetAllAsQuerable()
                                          where UploadTB.IsDeleted != true && UploadTB.UploadId == OrderTB.UploadId
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
                                          }).ToList()
                        }).ToList();
            return data;
        }
        public async Task<Guid> SaveOrder(SaveOrderDto request)
        {
            var saveOrder = new Order()
            {
                OrderId = Guid.NewGuid(),
                ProductId = request.ProductId,
                LanguageId = request.LanguageId,
                UserId = request.UserId,
                UploadId = request.UploadId,
                SampleId = request.SampleId,
                CreatedBy = request.CreatedBy,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false,
            };
            await _readWriteUnitOfWork.OrderRepository.AddAsync(saveOrder);
            await _readWriteUnitOfWork.CommitAsync();

            return saveOrder.OrderId;
        }

        public async Task<bool> UpdateOrder(UpdateOrderDto request)
        {
            var data = await _readWriteUnitOfWork.OrderRepository.GetFirstOrDefaultAsync(x => x.OrderId == request.OrderId);
            if (data != null)
            {
                data.ProductId = request.ProductId;
                data.LanguageId = request.LanguageId;
                data.UserId = request.UserId;
                data.UploadId = request.UploadId;
                data.SampleId = request.SampleId;
                data.UpdatedBy = request.UpdatedBy;
                data.UpdatedOn = DateTime.UtcNow;
                await _readWriteUnitOfWork.CommitAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteOrder(DeleteOrderDto request)
        {
            var data = await _readWriteUnitOfWork.OrderRepository.GetFirstOrDefaultAsync(x => x.OrderId == request.OrderId);
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
