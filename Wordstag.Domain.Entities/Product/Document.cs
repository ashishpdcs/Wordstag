using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wordstag.Domain.Entities.Product
{
    [Table("Document")]
    public class Document
    {
        [Key]
        public Guid Document_Id { get; set; }
        public string? Document_Name { get; set; }
        public string? Document_Description { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
    }
}
