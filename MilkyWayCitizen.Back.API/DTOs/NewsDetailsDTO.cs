namespace MilkyWayCitizen.Back.API.DTOs
{
    public class NewsDetailsDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Text { get; set; } = null!;
        public DateTime PublishTime { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; } = null!;
        public List<string> Pictures { get; set; } = null!;
        public List<string> Tags { get; set; } = null!;
    }
}
