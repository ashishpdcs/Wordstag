namespace Wordstag.API.Request.Order
{
    public class OrderRequest
    {
        public Guid? ProductId { get; set; }
        public Guid? LanguageId { get; set; }
        public Guid? UserId { get; set; }
        public Guid? UploadId { get; set; }
        public Guid? SampleId { get; set; }
        public Guid CreatedBy { get; set; }

    }
    public class GetOrderRequest
    {
        public Guid OrderId { get; set; }
    }
    public class SaveOrderRequest
    {
        public Guid? ProductId { get; set; }
        public Guid? LanguageId { get; set; }
        public Guid? UserId { get; set; }
        public Guid? UploadId { get; set; }
        public Guid? SampleId { get; set; }
        public Guid CreatedBy { get; set; }
    }
    public class UpdateOrderRequest
    {
        public Guid OrderId { get; set; }
        public Guid? ProductId { get; set; }
        public Guid? LanguageId { get; set; }
        public Guid? UserId { get; set; }
        public Guid? UploadId { get; set; }
        public Guid? SampleId { get; set; }
        public Guid UpdatedBy { get; set; }

    }
    public class DeleteOrderRequest
    {
        public Guid OrderId { get; set; }
    }
}
