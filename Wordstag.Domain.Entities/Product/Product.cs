using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Wordstag.Domain.Entities.Infrastructure;

namespace Wordstag.Domain.Entities.Product
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public Guid ProductTypeId { get; set; }
        public Guid? FromLanguage { get; set; }
        public Guid? ToLanguage { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public Guid PlanId { get; set; }
    }
}
