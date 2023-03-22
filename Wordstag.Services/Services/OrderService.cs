using AutoMapper;
using MailKit.Search;
using NPOI.OpenXmlFormats.Wordprocessing;
using NPOI.SS.Formula.Functions;
using Wordstag.Data.Contexts;
using Wordstag.Data.Infrastructure;
using Wordstag.Domain.Entities.Order;
using Wordstag.Services.Entities.Order;
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
        private readonly IFacebookService _facebookService;

        public OrderService(IUnitOfWork<ReadOnlyApplicationDbContext> readOnlyUnitOfWork,
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
        public async Task<List<GetOrderDto>> GetOrder(GetOrderDto request)
        {
            var data = (from OrderTB in _readOnlyUnitOfWork.OrderRepository.GetAllAsQuerable()
                        where OrderTB.Order_Id == request.Order_Id && OrderTB.IsDeleted != true
                        select new GetOrderDto
                        {
                            Order_Id = OrderTB.Order_Id,
                            Product_Id = OrderTB.Product_Id,
                            Language_Id = OrderTB.Language_Id,
                            User_Id = OrderTB.User_Id,
                            Upload_Id = OrderTB.Upload_Id,
                            Sample_Id = OrderTB.Sample_Id,
                            CreatedBy = OrderTB.CreatedBy,
                            CreatedOn = OrderTB.CreatedOn, 
                            UpdatedBy = OrderTB.UpdatedBy,
                            UpdatedOn = OrderTB.UpdatedOn,
                            IsDeleted = OrderTB.IsDeleted,
                        }).ToList();
            return data;
        }
        public async Task<List<GetOrderDto>> GetAllOrder()
        {
            var data = (from OrderTB in _readOnlyUnitOfWork.OrderRepository.GetAllAsQuerable()
                        where OrderTB.IsDeleted != true
                        select new GetOrderDto
                        {
                            Order_Id = OrderTB.Order_Id,
                            Product_Id = OrderTB.Product_Id,
                            Language_Id = OrderTB.Language_Id,
                            User_Id = OrderTB.User_Id,
                            Upload_Id = OrderTB.Upload_Id,
                            Sample_Id = OrderTB.Sample_Id,
                            CreatedBy = OrderTB.CreatedBy,
                            CreatedOn = OrderTB.CreatedOn,
                            UpdatedBy = OrderTB.UpdatedBy,
                            UpdatedOn = OrderTB.UpdatedOn,
                            IsDeleted = OrderTB.IsDeleted,
                        }).ToList();
            return data;
        }
        public async Task<Guid> SaveOrder(SaveOrderDto request)
        {
            var saveOrder = new Order()
            {
                Order_Id = Guid.NewGuid(),
                Product_Id = request.Product_Id,
                Language_Id = request.Language_Id,
                User_Id = request.User_Id,
                Upload_Id = request.Upload_Id,
                Sample_Id = request.Sample_Id,
                CreatedBy = request.CreatedBy,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false,
            };
            await _readWriteUnitOfWork.OrderRepository.AddAsync(saveOrder);
            await _readWriteUnitOfWork.CommitAsync();

            return saveOrder.Order_Id;
        }

        public async Task<bool> UpdateOrder(UpdateOrderDto request)
        {
            var data = await _readWriteUnitOfWork.OrderRepository.GetFirstOrDefaultAsync(x => x.Order_Id == request.Order_Id);
            if (data != null)
            {
                data.Product_Id = request.Product_Id;
                data.Language_Id = request.Language_Id;
                data.User_Id = request.User_Id;
                data.Upload_Id = request.Upload_Id;
                data.Sample_Id = request.Sample_Id;
                data.UpdatedBy = request.UpdatedBy;
                data.UpdatedOn = DateTime.UtcNow;
                await _readWriteUnitOfWork.CommitAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteOrder(DeleteOrderDto request)
        {
            var data = await _readWriteUnitOfWork.OrderRepository.GetFirstOrDefaultAsync(x => x.Order_Id == request.Order_Id);
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
