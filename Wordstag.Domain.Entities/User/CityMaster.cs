using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordstag.Domain.Entities.User
{
    [Table("CityMaster")]
    public class CityMaster
    {
        [Key]
        public int ID { get; set; }
        public string? CityName { get; set; }
        public int? StateId { get; set; }
    }
}
