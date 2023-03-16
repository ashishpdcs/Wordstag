using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wordstag.Domain.Entities.Product
{
    [Table("Product")]
    public class Product
    {
        [Key]
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
        public bool IsDeleted { get; set; }
    }
}
