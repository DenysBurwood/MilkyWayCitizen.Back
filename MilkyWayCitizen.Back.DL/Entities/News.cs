
namespace MilkyWayCitizen.Back.DL.Entities
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;    //  If news article without any description, the first n first characters are used as a Description
        public string Text { get; set; } = null!;
        public DateTime PublishTime { get; set; }
        public int UserId { get; set; }
        public User Author { get; set; } = null!;
        public List<string> Pictures { get; set; } = null!;
        public List<string> Tags { get; set; } = null!;
    }
}
