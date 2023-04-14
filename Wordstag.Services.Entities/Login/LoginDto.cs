using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordstag.Services.Entities.Login
{
    public class LoginDto
    {
        public Guid Id { get; set; }
        public Guid Registeer_Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }   
        public string Mobile { get; set; }
        public string New_Password { get; set; }
        public string UserType { get; set; }
        public DateTime LoginDate { get; set; }
        public string? RefreshToken { get; set; }
        public string? InvitationToken { get; set; }
        public string? JwtToken { get; set; }
    }
}
