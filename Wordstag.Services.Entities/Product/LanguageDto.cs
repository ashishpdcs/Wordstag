using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordstag.Services.Entities.Product
{
    public class LanguageDto
    {
        public string? LanguageName { get; set; }
        public string? LanguageCode { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Guid CreatedBy { get; set; }

    }
    public class GetLanguageDto
    {
        public Guid? LanguageId { get; set; }
        public string? LanguageName { get; set; }
        public string? LanguageCode { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }

    }
    public class SaveLanguageDto
    {
        public string? LanguageName { get; set; }
        public string? LanguageCode { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }
    }
    public class UpdateLanguageDto
    {
        public Guid LanguageId { get; set; }
        public string? LanguageName { get; set; }
        public string? LanguageCode { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Guid UpdatedBy { get; set; }

    }
    public class DeleteLanguageDto
    {
        public Guid LanguageId { get; set; }
    }
}
