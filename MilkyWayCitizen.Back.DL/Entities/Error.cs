
namespace MilkyWayCitizen.Back.DL.Entities
{
    public class Error
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string Message { get; set; } = null!;
        public DateTime TimeError { get; set; }
    }
}
