
namespace Wordstag.Services.Entities.User
{
    public class SessionDetailsDto
    {
        public Guid UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int CurrentConnectionId { get; set; }
    }
}
