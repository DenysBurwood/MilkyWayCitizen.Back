
namespace MilkyWayCitizen.Back.DL.Entities
{
    public class Comment
    {
        public long Id { get; set; }
        public string Text { get; set; } = null!;
        public DateTime PublishTime { get; set; }
        //public Likes Likes {get; set;}
        public News News { get; set; } = null!;
        public int NewsId { get; set; }
        //public int? ResponseId { get; set; }
        //public Comment? Response { get; set; }
        public User Author { get; set; } = null!;
        public int AuthorId { get; set; }
    }
}
