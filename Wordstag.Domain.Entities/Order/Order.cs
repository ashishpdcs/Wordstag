using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wordstag.Domain.Entities.Order
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public Guid Order_Id { get; set; }
        public Guid? Product_Id { get; set; }
        public Guid? Language_Id { get; set; }
        public Guid? User_Id { get; set; }
        public Guid? Upload_Id { get; set; }
        public Guid? Sample_Id { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
