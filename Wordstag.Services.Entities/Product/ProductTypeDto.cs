using Wordstag.Services.Entities.Common;

namespace Wordstag.Services.Entities.Product
{
    public class ProductTypeDto
    {
        public string? ProductTypeName { get; set; }
        public string? ProductTypeDescription { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Guid CreatedBy { get; set; }

    }
    public class GetProductTypeDto : PaginationDto
    {
        public Guid? TypeId { get; set; }
        public string? ProductTypeName { get; set; }
        public string? ProductTypeDescription { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }

    }
    public class SaveProductTypeDto
    {
        public string? ProductTypeName { get; set; }
        public string? ProductTypeDescription { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }
    }
    public class UpdateProductTypeDto
    {
        public Guid TypeId { get; set; }
        public string? ProductTypeName { get; set; }
        public string? ProductTypeDescription { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Guid UpdatedBy { get; set; }

    }
    public class DeleteProductTypeDto
    {
        public Guid TypeId { get; set; }
    }
}
