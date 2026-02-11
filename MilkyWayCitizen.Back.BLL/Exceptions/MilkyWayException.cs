
namespace MilkyWayCitizen.Back.BLL.Exceptions
{
    public abstract class MilkyWayException:Exception
    {
        public int StatusCode { get; set; }
        public Object Content { get; set; } = null!;
        public MilkyWayException(int statusCode, Object content) 
        {
            StatusCode = statusCode;
            Content = content;
        }
    }
}
