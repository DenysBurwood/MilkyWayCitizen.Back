
namespace MilkyWayCitizen.Back.BLL.Exceptions
{
    public class NewsFormException:MilkyWayException
    {
        public NewsFormException() : base(400,"Invalid form"){}
        public NewsFormException(string message):base(400, message){}
    }
}
