using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordstag.Services.Entities.Product
{
    public class ProductTypeDto
    {
        public string? ProductType_Name { get; set; }
        public string? ProductType_Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Guid CreatedBy { get; set; }

    }
    public class GetProductTypeDto
    {
        public Guid? TypeId { get; set; }
        public string? ProductType_Name { get; set; }
        public string? ProductType_Description { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }

    }
    public class SaveProductTypeDto
    {
        public string? ProductType_Name { get; set; }
        public string? ProductType_Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }
    }
    public class UpdateProductTypeDto
    {
        public Guid TypeId { get; set; }
        public string? ProductType_Name { get; set; }
        public string? ProductType_Description { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Guid UpdatedBy { get; set; }

    }
    public class DeleteProductTypeDto
    {
        public Guid TypeId { get; set; }
    }
}
