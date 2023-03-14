using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordstag.Domain.Entities.User
{

    [Table("CountryMaster")]
    public class CountryMaster
    {
        [Key]
        public int ID { get; set; }
        public string? CountryName { get; set; }
        public string? CountryCode { get; set; }
    }
}
