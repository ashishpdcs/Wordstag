using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wordstag.Domain.Entities.UserSample
{
    [Table("User_Sample")]
    public class UserSample
    {
        [Key]
        public Guid Id { get; set; }
        public Guid? Language_Id { get; set; }
        public Guid? User_Id { get; set; }
        public Guid? Upload_Id { get; set; }
        public Guid? Product_TypeId { get; set; }
        public string? Approve { get; set; }
        public Guid? Approve_Id { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
