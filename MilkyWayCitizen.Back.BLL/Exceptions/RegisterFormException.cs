
namespace MilkyWayCitizen.Back.BLL.Exceptions
{
    public class RegisterFormException:MilkyWayException
    {
        public RegisterFormException() : base(400,"invalid register form"){}
        public RegisterFormException(string message) : base(400,message) { }
    }
}
