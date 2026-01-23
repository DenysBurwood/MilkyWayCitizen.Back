using MilkyWayCitizen.Back.DL.Entities;

namespace MilkyWayCitizen.Back.API.DTOs
{
    public class UserDetailsDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateOnly BirthDate { get; set; }
        public List<News>? PublishedNews { get; set; }
    }
}
