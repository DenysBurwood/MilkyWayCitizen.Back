using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MilkyWayCitizen.Back.API.DTOs;
using MilkyWayCitizen.Back.API.Mappers;
using MilkyWayCitizen.Back.API.Tools;
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
        public ActionResult NewsIndex([FromQuery] int pageSize = 10,[FromQuery] int pageNumber = 0,[FromQuery] string[]? tags = null)
        {
            List<NewsIndexDTO> articles = _newsService.GetNews(pageNumber,pageSize,tags).Select(n => n.ToNewsIndexDTOFromNews()).ToList();
            NewsIndexPageMaxDTO groupArticles = new NewsIndexPageMaxDTO(articles,(int)(Math.Ceiling(1.0*_newsService.NumberPageMax(pageSize,tags)/pageSize)));
            return Ok(groupArticles);
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
            User? author = _userService.GetUserById(news.UserId);
            if(author==null)
            {
                throw new Exception("Author not found");
            }
            newsDetails.AuthorName=author.UserName;
            //news.Author=author;
            return Ok(newsDetails);
        }

        [Authorize(Roles ="admin,moderator")]
        [HttpPost("add")]
        public ActionResult AddNews([FromBody] NewsFormDTO news) 
        {
            //  Publish time is lost in the body
            //Console.Write("\nPublishTime : ");
            //Console.WriteLine(news.PublishTime);
            news.UserId=User.GetUserID();
            //throw new Exception("stop temporaire");
            _newsService.AddNews(news.ToNewsFromNewsFormDTO());
            return Ok();
        }

        [HttpGet("pageNumberMax")]
        public ActionResult NumberPageMax([FromQuery] int pageSize,[FromQuery] string[]? tags) 
        {
            if(tags!=null) 
            {
                if(tags.Length>0) 
                {
                    Console.WriteLine(tags[0]);
                    if(tags.Length>1) 
                    {
                        Console.WriteLine(tags[1]);
                    }
                }
            
            }
            return Ok(_newsService.NumberPageMax(pageSize,tags));
        }
    }
}
