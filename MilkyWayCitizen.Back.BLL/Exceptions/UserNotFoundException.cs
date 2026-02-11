
namespace MilkyWayCitizen.Back.BLL.Exceptions
{
    public class UserNotFoundException:MilkyWayException
    {
        public UserNotFoundException(object content) : base(400,content){}
        public UserNotFoundException() : base(400,"User not found") { }
    }
}
