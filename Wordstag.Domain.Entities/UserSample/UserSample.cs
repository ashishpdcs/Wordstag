using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wordstag.Domain.Entities.UserSample
{
    [Table("UserSample")]
    public class UserSample
    {
        [Key]
        public Guid Id { get; set; }
        public Guid? LanguageId { get; set; }
        public Guid? UserId { get; set; }
        public Guid? UploadId { get; set; }
        public Guid? ProductTypeId { get; set; }
        public string? Approve { get; set; }
        public Guid? ApproveId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
