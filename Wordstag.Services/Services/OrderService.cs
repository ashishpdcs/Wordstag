using AutoMapper;
using MailKit.Search;
using NPOI.OpenXmlFormats.Wordprocessing;
using NPOI.SS.Formula.Functions;
using System.Linq;
using Wordstag.Data.Contexts;
using Wordstag.Data.Infrastructure;
using Wordstag.Domain.Entities.Order;
using Wordstag.Domain.Entities.Product;
using Wordstag.Domain.Entities.Upload;
using Wordstag.Services.Entities;
using Wordstag.Services.Entities.Common;
using Wordstag.Services.Entities.Order;
using Wordstag.Services.Entities.Product;
using Wordstag.Services.Entities.Upload;
using Wordstag.Services.Entities.User;
using Wordstag.Services.Infrastructure;
using Wordstag.Services.Interfaces;
using Wordstag.Utility;

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
                            OrderNo = OrderTB.OrderNo,
                            ProductId = OrderTB.ProductId,
                            FromLanguageId = OrderTB.FromLanguageId,
                            ToLanguageId = OrderTB.ToLanguageId,
                            UserId = OrderTB.UserId,
                            UploadId = OrderTB.UploadId,
                            SampleId = OrderTB.SampleId,
                            Items = OrderTB.Items,
                            NoofWords = OrderTB.NoofWords,
                            CreatedBy = OrderTB.CreatedBy,
                            CreatedOn = OrderTB.CreatedOn,
                            UpdatedBy = OrderTB.UpdatedBy,
                            UpdatedOn = OrderTB.UpdatedOn,
                            IsDeleted = OrderTB.IsDeleted,
                            OrderDescription = OrderTB.OrderDescription,
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
        public async Task<GenericList<GetOrderDto>> GetAllOrder(PaginationDto paginationDto)
        {
            var dataQuery = (from OrderTB in _readOnlyUnitOfWork.OrderRepository.GetAllAsQuerable()
                        where OrderTB.IsDeleted != true
                        select new GetOrderDto
                        {
                            OrderId = OrderTB.OrderId,
                            OrderNo = OrderTB.OrderNo,
                            ProductId = OrderTB.ProductId,
                            FromLanguageId = OrderTB.FromLanguageId,
                            ToLanguageId = OrderTB.ToLanguageId,
                            UserId = OrderTB.UserId,
                            UploadId = OrderTB.UploadId,
                            SampleId = OrderTB.SampleId,
                            Items = OrderTB.Items,
                            NoofWords = OrderTB.NoofWords,
                            CreatedBy = OrderTB.CreatedBy,
                            CreatedOn = OrderTB.CreatedOn,
                            UpdatedBy = OrderTB.UpdatedBy,
                            UpdatedOn = OrderTB.UpdatedOn,
                            IsDeleted = OrderTB.IsDeleted,
                            OrderDescription = OrderTB.OrderDescription,
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
                        });
            if (!string.IsNullOrEmpty(paginationDto.OrderBy))
            {
                dataQuery = dataQuery.OrderByDynamic(paginationDto.OrderBy, paginationDto.OrderDirection);
            }
            if (!string.IsNullOrEmpty(paginationDto.GlobalSearch))
            {
                dataQuery = dataQuery.Where(x => x.OrderNo.Contains(paginationDto.GlobalSearch)
                || (x.OrderNo != null && x.OrderNo.Contains(paginationDto.GlobalSearch))
                || (GenericMethods.checkStringIsValidDateTime(paginationDto.GlobalSearch) == true && x.CreatedOn == Convert.ToDateTime(paginationDto.GlobalSearch))
                || (GenericMethods.checkStringIsValidDateTime(paginationDto.GlobalSearch) == true && x.UpdatedOn != null && x.UpdatedOn == Convert.ToDateTime(paginationDto.GlobalSearch))
                );
            }

            // Before calculate count if required any filter then apply that first then applied pagination
            var dataCount = dataQuery.Count();
            var data = new GenericList<GetOrderDto>();
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
        public async Task<Guid> SaveOrder(SaveOrderDto request)
        {
            Random random = new Random();
            string randomNumberString = random.Next(100000, 999999).ToString();
            var saveOrder = new Order()
            {
                OrderId = Guid.NewGuid(),
                OrderNo = randomNumberString,
                ProductId = request.ProductId,
                FromLanguageId = request.FromLanguageId,
                ToLanguageId = request.ToLanguageId,
                UserId = request.UserId,
                UploadId = request.UploadId,
                SampleId = request.SampleId,
                Items = request.Items,
                NoofWords = request.NoofWords,
                CreatedBy = request.CreatedBy,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false,
                OrderDescription = request.OrderDescription,
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
                data.ToLanguageId = request.ToLanguageId;
                data.FromLanguageId = request.FromLanguageId;
                data.UserId = request.UserId;
                data.UploadId = request.UploadId;
                data.SampleId = request.SampleId;
                data.Items = request.Items;
                data.NoofWords = request.NoofWords;
                data.UpdatedBy = request.UpdatedBy;
                data.UpdatedOn = DateTime.UtcNow;
                data.OrderDescription = request.OrderDescription;
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
