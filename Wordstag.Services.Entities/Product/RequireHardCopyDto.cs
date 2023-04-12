using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordstag.Domain.Entities.Product;

namespace Wordstag.Services.Entities.Product
{
    public class RequireHardCopyDto
    {
        public int Id { get; set; }
        public string? Details { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
      
    }

    public class SaveRequireHardCopyDto
    {
        public string? Details { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? CreatedBy { get; set; }

    }
    public class GetRequireHardCopyDto
    {
        public int Id { get; set; }
        public string? Details { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
    }
    public class UpdateRequireHardCopyDto
    {
        public int Id { get; set; }
        public string? Details { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? UpdatedBy { get; set; }
    }
    public class DeleteRequireHardCopyDto
    {
        public int Id { get; set; }
       
    }


}
