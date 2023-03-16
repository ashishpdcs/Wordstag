namespace Wordstag.API.Request.Product
{
    public class ProductRequest
    {
        public string? Product_Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public Guid Product_TypeId { get; set; }
        public string? From_Language { get; set; }
        public string? To_Language { get; set; }
        public Guid CreatedBy { get; set; }

    }
    public class GetProductRequest
    {
        public Guid Product_Id { get; set; }
    }
    public class SaveProductRequest
    {
        public string? Product_Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public Guid Product_TypeId { get; set; }
        public string? From_Language { get; set; }
        public string? To_Language { get; set; }
        public Guid CreatedBy { get; set; }
    }
    public class UpdateProductRequest
    {
        public Guid Product_Id { get; set; }
        public string? Product_Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public Guid Product_TypeId { get; set; }
        public string? From_Language { get; set; }
        public string? To_Language { get; set; }
        public Guid UpdatedBy { get; set; }

    }
    public class DeleteProductRequest
    {
        public Guid Product_Id { get; set; }
    }
}
