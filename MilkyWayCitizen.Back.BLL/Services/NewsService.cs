
using Microsoft.AspNetCore.Authorization;
using MilkyWayCitizen.Back.DAL.Repositories;
using MilkyWayCitizen.Back.DL.Entities;

namespace MilkyWayCitizen.Back.BLL.Services
{
    public class NewsService
    {
        private readonly NewsRepository _news;
        private readonly UserRepository _user;
        public NewsService(NewsRepository news, UserRepository user) 
        {
            _user = user;
            _news = news;
        }
        public List<News> GetNews() 
        {
            return _news.GetNews();
        }
        public News? GetOneNews(int id) 
        {
            return _news.GetOneNews(id);
        }

        //[Authorize(Roles = "Admin")]
        public void AddNews(News news) 
        {
            news.Author=_user.GetUserById(news.UserId)!;  //  Check afterwards how to handle no user found
            _news.AddNews(news);
        }
    }
}
