using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wordstag.Domain.Entities.Product
{
    [Table("Document")]
    public class Document
    {
        [Key]
        public Guid DocumentId { get; set; }
        public string? DocumentName { get; set; }
        public string? DocumentDescription { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
    }
}
