namespace Wordstag.API.Request.Product
{
    public class ProductTypeRequest
    {
        public string? ProductType_Name { get; set; }
        public string? ProductType_Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Guid CreatedBy { get; set; }

    }
    public class GetProductTypeRequest
    {
        public Guid TypeId { get; set; }
    }
    public class SaveProductTypeRequest
    {
        public string? ProductType_Name { get; set; }
        public string? ProductType_Description { get; set; }
        public Guid CreatedBy { get; set; }
    }
    public class UpdateProductTypeRequest
    {
        public Guid TypeId { get; set; }
        public string? ProductType_Name { get; set; }
        public string? ProductType_Description { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Guid UpdatedBy { get; set; }

    }
    public class DeleteProductTypeRequest
    {
        public Guid TypeId { get; set; }
    }
}
