using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wordstag.Domain.Entities.Product
{
    [Table("Product_Type")]
    public class ProductType
    {
        [Key]
        public Guid TypeId { get; set; }
        public string? ProductType_Name { get; set; }
        public string? ProductType_Description { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
