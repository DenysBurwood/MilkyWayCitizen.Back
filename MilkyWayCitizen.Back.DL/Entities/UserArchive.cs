
namespace MilkyWayCitizen.Back.DL.Entities
{
    public class UserArchive
    {
        public long Id { get; set; }
        public int? UserId { get; set; }
        public string? UserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public DateOnly? BirthDate { get; set; }
    }
}
