using System.ComponentModel.DataAnnotations;

namespace MilkyWayCitizen.Back.API.DTOs
{
    public class NewsIndexDTO()
    {
        public int Id { get; set; }
        public string Title { get; set; } =null!;
        public string Description { get; set; } = null!;
        public List<string> Tags { get; set; } = null!;
        public string Picture { get; set; } = null!;
    }
}
