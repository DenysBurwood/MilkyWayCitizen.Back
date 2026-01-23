using Microsoft.AspNetCore.Mvc;
using MilkyWayCitizen.Back.API.DTOs;
using MilkyWayCitizen.Back.API.Mappers;
using MilkyWayCitizen.Back.BLL.Services;
using MilkyWayCitizen.Back.DL.Entities;

namespace MilkyWayCitizen.Back.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NewsController:ControllerBase
    {
        private readonly NewsService _newsService;
        private readonly UserService _userService;
        public NewsController(NewsService newsService, UserService userService)
        {
            _newsService=newsService;
            _userService=userService;
        }

         [HttpGet("index")]
        public ActionResult NewsIndex() 
        {
            List<NewsIndexDTO> articles = _newsService.GetNews().Select(n => n.ToNewsIndexDTOFromNews()).ToList();
            return Ok(articles);
        }

        [HttpGet("details/{id}")]
        public ActionResult OneNews([FromRoute] int id) 
        {
            News? news = _newsService.GetOneNews(id);
            if(news==null) 
            {
                throw new Exception("No such title found£...");
            }
            NewsDetailsDTO newsDetails = news.ToNewsDetailsDTOFromNews();
            Console.WriteLine("UserId : " + newsDetails.AuthorId);
            Console.WriteLine("Photos : " + newsDetails.Pictures);
            User? author = _userService.GetUserById(news.UserId);
            if(author==null)
            {
                throw new Exception("Author not found");
            }
            newsDetails.AuthorName=author.UserName;
            //news.Author=author;
            return Ok(newsDetails);
        }

        [HttpPost("add")]
        public ActionResult AddNews([FromBody] NewsFormDTO news) 
        {
            Console.Write("\nPublishTime : ");
            Console.WriteLine(news.PublishTime);
            _newsService.AddNews(news.ToNewsFromNewsFormDTO());
            return Ok();
        }
    }
}
