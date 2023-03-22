namespace Wordstag.API.Request.Order
{
    public class OrderRequest
    {
        public Guid? Product_Id { get; set; }
        public Guid? Language_Id { get; set; }
        public Guid? User_Id { get; set; }
        public Guid? Upload_Id { get; set; }
        public Guid? Sample_Id { get; set; }
        public Guid CreatedBy { get; set; }

    }
    public class GetOrderRequest
    {
        public Guid Order_Id { get; set; }
    }
    public class SaveOrderRequest
    {
        public Guid? Product_Id { get; set; }
        public Guid? Language_Id { get; set; }
        public Guid? User_Id { get; set; }
        public Guid? Upload_Id { get; set; }
        public Guid? Sample_Id { get; set; }
        public Guid CreatedBy { get; set; }
    }
    public class UpdateOrderRequest
    {
        public Guid Order_Id { get; set; }
        public Guid? Product_Id { get; set; }
        public Guid? Language_Id { get; set; }
        public Guid? User_Id { get; set; }
        public Guid? Upload_Id { get; set; }
        public Guid? Sample_Id { get; set; }
        public Guid UpdatedBy { get; set; }

    }
    public class DeleteOrderRequest
    {
        public Guid Order_Id { get; set; }
    }
}
