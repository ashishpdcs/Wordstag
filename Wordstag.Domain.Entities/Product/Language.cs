using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wordstag.Domain.Entities.Product
{
    [Table("Language")]
    public class Language
    {
        [Key]
        public Guid LanguageId { get; set; }
        public string? Language_Name { get; set; }
        public string? Language_Code { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
        //public bool IsDeleted { get; set; }
    }
}
