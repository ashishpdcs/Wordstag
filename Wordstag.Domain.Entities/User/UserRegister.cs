using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordstag.Domain.Entities.User
{
    [Table("Register")]
    public class UserRegister
    {
        [Key]
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailAddress { get; set; }
        public string? MobileNo { get; set; }
        public string? Image { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Gender { get; set; }
        public string? UserToken { get; set; }
        public string? Address { get; set; }
        public int? CityId { get; set; }
        public int? StateId { get; set; }
        public int? CountryId { get; set; }
        public int? Zipcode { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

    }
}
