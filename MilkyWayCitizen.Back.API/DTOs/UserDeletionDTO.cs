namespace MilkyWayCitizen.Back.API.DTOs
{
    public class UserDeletionDTO
    {
        public int UserId { get; set; }
        public string Password { get; set; } = null!;
    }
}
