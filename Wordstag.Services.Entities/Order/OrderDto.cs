
namespace Wordstag.Services.Entities.Order
{
    public class OrderDto
    {
        public Guid? Product_Id { get; set; }
        public Guid? Language_Id { get; set; }
        public Guid? User_Id { get; set; }
        public Guid? Upload_Id { get; set; }
        public Guid? Sample_Id { get; set; }
        public Guid CreatedBy { get; set; }

    }
    public class GetOrderDto
    {
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
        public bool? IsDeleted { get; set; }

    }
    public class SaveOrderDto
    {
        public Guid? Product_Id { get; set; }
        public Guid? Language_Id { get; set; }
        public Guid? User_Id { get; set; }
        public Guid? Upload_Id { get; set; }
        public Guid? Sample_Id { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class UpdateOrderDto
    {
        public Guid Order_Id { get; set; }
        public Guid? Product_Id { get; set; }
        public Guid? Language_Id { get; set; }
        public Guid? User_Id { get; set; }
        public Guid? Upload_Id { get; set; }
        public Guid? Sample_Id { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }

    }
    public class DeleteOrderDto
    {
        public Guid Order_Id { get; set; }
    }
}
