﻿namespace Wordstag.API.Request.Product
{
    public class ProductRequest
    {
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public Guid ProductTypeId { get; set; }
        public string? FromLanguage { get; set; }
        public string? ToLanguage { get; set; }
        public Guid CreatedBy { get; set; }

    }
    public class GetProductRequest
    {
        public Guid ProductId { get; set; }
    }
    public class SaveProductRequest
    {
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public Guid ProductTypeId { get; set; }
        public string? FromLanguage { get; set; }
        public string? ToLanguage { get; set; }
        public Guid CreatedBy { get; set; }
    }
    public class UpdateProductRequest
    {
        public Guid ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public Guid ProductTypeId { get; set; }
        public string? FromLanguage { get; set; }
        public string? ToLanguage { get; set; }
        public Guid UpdatedBy { get; set; }

    }
    public class DeleteProductRequest
    {
        public Guid ProductId { get; set; }
    }
}
