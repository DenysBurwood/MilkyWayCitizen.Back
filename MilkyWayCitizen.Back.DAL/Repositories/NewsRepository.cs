
using Microsoft.EntityFrameworkCore;
using MilkyWayCitizen.Back.DAL.Contexts;
using MilkyWayCitizen.Back.DL.Entities;
using System.Linq;

namespace MilkyWayCitizen.Back.DAL.Repositories
{
    public class NewsRepository
    {
        private readonly DbSet<News> _news;
        private readonly MilkyWayContext _context;
        public NewsRepository(MilkyWayContext context) 
        {
            _news=context.News;
            _context = context;
        }
        public List<News> GetNews(int pageNumber, int pageSize,string[]? tags) 
        {
            List<News> selectedNews = _news.OrderBy(n => EF.Property<News>(n,"Id")).ToList();
            if(tags!=null) 
            {
                foreach(string tag in tags) 
                {
                    selectedNews = selectedNews.FindAll(article => article.Tags.Contains(tag)).ToList();
                    Console.WriteLine("bouclette");
                }
            }
            selectedNews=selectedNews.Skip(pageSize*pageNumber).Take(pageSize).ToList();
            return selectedNews;
        }
        public News? GetOneNews(int id) 
        {
            return _news.FirstOrDefault(n => n.Id == id);
        }


        public void AddNews(News news) 
        {
            _news.Add(news);
            _context.SaveChanges();
        }
    }
}
