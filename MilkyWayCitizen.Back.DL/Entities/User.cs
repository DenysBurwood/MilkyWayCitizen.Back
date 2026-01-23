
using MilkyWayCitizen.Back.DL.Enums;

namespace MilkyWayCitizen.Back.DL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateOnly BirthDate { get; set; }
        public Roles Role {  get; set; }
        public List<News>? PublishedNews { get; set; }
        public int AddressID { get; set; }
        public Address Address { get; set; } = null!;

    }
}
