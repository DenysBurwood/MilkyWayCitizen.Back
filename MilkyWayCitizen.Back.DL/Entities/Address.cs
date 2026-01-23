
namespace MilkyWayCitizen.Back.DL.Entities
{
    public class Address
    {
        public int ID { get; set; }
        public string StreetName { get; set; } = null!;
        public int StreetNumber { get; set; }
        //public string? PostalBox { get; set; }
        public string City { get; set; } = null!;
        public string Contry { get; set; } = null!;
        public int? UserID { get; set; }
        public User? User { get; set; } = null!;

    }
}
