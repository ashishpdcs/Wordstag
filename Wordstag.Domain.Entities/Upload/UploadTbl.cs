using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Wordstag.Domain.Entities.User;

namespace Wordstag.Domain.Entities.Upload
{
    [Table("Upload")]
    public class UploadTbl
    {
        [Key]
        public Guid Upload_Id { get; set; }
        public Guid? Product_Id { get; set; }
        public Guid? Language_Id { get; set; }
        public Guid? User_Id { get; set; }
        public string? Orignal_File { get; set; }
        public string? Updated_File { get; set; }
        public string? File_Path { get; set; }
        public string? File_Size { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
