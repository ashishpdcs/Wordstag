using System.ComponentModel.DataAnnotations;

namespace Wordstag.API.Request.Product
{
    public class SaveProductservicesevice
    {
        public Guid? ProductId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public float? Price { get; set; }
        public int? ParentId { get; set; }
        public string? TypeOfElement { get; set; }

    }
    public class GetProductservicesevice
    {
        public Guid? ProductId { get; set; }

    }
}
