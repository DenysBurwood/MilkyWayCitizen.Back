using MilkyWayCitizen.Back.API.DTOs;
using MilkyWayCitizen.Back.DL.Entities;

namespace MilkyWayCitizen.Back.API.Mappers
{
    public static class NewsMapper
    {
        public static NewsIndexDTO ToNewsIndexDTOFromNews(this News news) 
        {
            return new NewsIndexDTO()
            {
                Id = news.Id,
                Title = news.Title,
                Picture = news.Pictures.First(),//[0],
                Tags = news.Tags,
                Description = news.Description.Length<100 ? news.Description : "Lorem Ipsum",
                //  Not here it's supposed to happen. The 'description' field must be created before the news is saved.
            };
        }

        public static News ToNewsFromNewsFormDTO(this NewsFormDTO news) 
        {
            return new News()
            {
                Title=news.Title,
                Description=news.Description,
                UserId=news.UserId,
                Pictures=news.Pictures,
                Tags=news.Tags,
                PublishTime=news.PublishTime,
                Text=news.Text,
            };
        }
        public static NewsDetailsDTO ToNewsDetailsDTOFromNews(this News news) 
        {
            return new NewsDetailsDTO() 
            {
                Id = news.Id,
                Title= news.Title,
                Text=news.Text,
                PublishTime = news.PublishTime,
                AuthorId=news.UserId,
                Tags=news.Tags,
                Pictures=news.Pictures,
            };
        }
    }
}
