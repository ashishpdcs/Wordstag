
using Wordstag.Services.Entities.Common;
using Wordstag.Services.Entities.Product;
using Wordstag.Services.Entities.Upload;
using Wordstag.Services.Entities.User;

namespace Wordstag.Services.Entities.Order
{
    public class OrderDto
    {
        public Guid? ProductId { get; set; }
        public Guid? FromLanguageId { get; set; }
        public Guid? ToLanguageId { get; set; }
        public Guid? UserId { get; set; }
        public Guid? UploadId { get; set; }
        public Guid? SampleId { get; set; }
        public int Items { get; set; }
        public int NoofWords { get; set; }
        public Guid CreatedBy { get; set; }

    }
    public class GetOrderDto : PaginationDto
    {
        public Guid OrderId { get; set; }
        public string? OrderNo { get; set; }
        public Guid? ProductId { get; set; }
        public Guid? FromLanguageId { get; set; }
        public Guid? ToLanguageId { get; set; }
        public Guid? UserId { get; set; }
        public Guid? UploadId { get; set; }
        public Guid? SampleId { get; set; }
        public int? Items { get; set; }
        public int? NoofWords { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }

        public List<GetProductDto> productDtos { get; set; }
        public List<GetUserRegisterDto> UserRegisterDtos { get; set; }
        public List<GetUploadDto> UploadDtos { get; set; }

    }
    public class SaveOrderDto
    {
        public string? OrderNo { get; set; }
        public Guid? ProductId { get; set; }
        public Guid? FromLanguageId { get; set; }
        public Guid? ToLanguageId { get; set; }
        public Guid? UserId { get; set; }
        public Guid? UploadId { get; set; }
        public Guid? SampleId { get; set; }
        public int Items { get; set; }
        public int NoofWords { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class UpdateOrderDto
    {
        public Guid OrderId { get; set; }
        public Guid? ProductId { get; set; }
        public Guid? FromLanguageId { get; set; }
        public Guid? ToLanguageId { get; set; }
        public Guid? UserId { get; set; }
        public Guid? UploadId { get; set; }
        public Guid? SampleId { get; set; }
        public int Items { get; set; }
        public int NoofWords { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }

    }
    public class DeleteOrderDto
    {
        public Guid OrderId { get; set; }
    }
}
