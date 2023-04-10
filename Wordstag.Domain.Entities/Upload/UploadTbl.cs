using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Wordstag.Domain.Entities.User;

namespace Wordstag.Domain.Entities.Upload
{
    [Table("Upload")]
    public class UploadTbl
    {
        [Key]
        public Guid UploadId { get; set; }
        public Guid? ProductId { get; set; }
        public Guid? LanguageId { get; set; }
        public Guid? UserId { get; set; }
        public string? FileName { get; set; }
        public string? FileType { get; set; }
        public string? OrignalFile { get; set; }
        public string? UpdatedFile { get; set; }
        public string? FilePath { get; set; }
        public string? FileSize { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
