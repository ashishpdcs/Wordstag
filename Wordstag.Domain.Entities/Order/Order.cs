using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wordstag.Domain.Entities.Order
{
    [Table("Order")]
    public class Order
    {
        [Key]
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
        public bool IsDeleted { get; set; }
        public string? OrderDescription { get; set; }
    }
}
