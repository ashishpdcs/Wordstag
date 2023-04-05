using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordstag.Domain.Entities.Product;
using Wordstag.Services.Entities.Common;

namespace Wordstag.Services.Entities.Product
{
    public class ProductDto
    {
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public Guid ProductTypeId { get; set; }
        public string? FromLanguage { get; set; }
        public string? ToLanguage { get; set; }
        public Guid CreatedBy { get; set; }

    }
    public class GetProductDto : PaginationDto
    {
        public Guid ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public Guid ProductTypeId { get; set; }
        public string? FromLanguage { get; set; }
        public string? ToLanguage { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public Guid PlanId { get; set; }
        public List<GetProductTypeDto> productTypes { get; set; }
        public List<GetPlanDto> planTypes { get; set; }

    }
    public class SaveProductDto
    {
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public Guid ProductTypeId { get; set; }
        public string? FromLanguage { get; set; }
        public string? ToLanguage { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public Guid PlanId { get; set; }
    }
    public class UpdateProductDto
    {
        public Guid ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public Guid ProductTypeId { get; set; }
        public string? FromLanguage { get; set; }
        public string? ToLanguage { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }

    }
    public class DeleteProductDto
    {
        public Guid ProductId { get; set; }
    }
}
