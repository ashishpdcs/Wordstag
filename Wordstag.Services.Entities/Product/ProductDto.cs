using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordstag.Services.Entities.Product
{
    public class ProductDto
    {
        public string? Product_Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public Guid Product_TypeId { get; set; }
        public string? From_Language { get; set; }
        public string? To_Language { get; set; }
        public Guid CreatedBy { get; set; }

    }
    public class GetProductDto
    {
        public Guid Product_Id { get; set; }
        public string? Product_Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public Guid Product_TypeID { get; set; }
        public string? From_Language { get; set; }
        public string? To_Language { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }

    }
    public class SaveProductDto
    {
        public string? Product_Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public Guid Product_TypeID { get; set; }
        public string? From_Language { get; set; }
        public string? To_Language { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class UpdateProductDto
    {
        public Guid Product_Id { get; set; }
        public string? Product_Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public Guid Product_TypeID { get; set; }
        public string? From_Language { get; set; }
        public string? To_Language { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }

    }
    public class DeleteProductDto
    {
        public Guid Product_Id { get; set; }
    }
}
