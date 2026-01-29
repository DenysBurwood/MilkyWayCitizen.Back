
using Microsoft.EntityFrameworkCore;
using MilkyWayCitizen.Back.DAL.Contexts;
using MilkyWayCitizen.Back.DL.Entities;

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
        public List<News> GetNews() 
        {
            return _news.OrderBy(n => EF.Property<News>(n,"Id")).ToList();
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
