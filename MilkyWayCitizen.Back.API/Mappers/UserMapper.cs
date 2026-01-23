using MilkyWayCitizen.Back.API.DTOs;
using MilkyWayCitizen.Back.DL.Entities;

namespace MilkyWayCitizen.Back.API.Mappers
{
    public static class UserMapper
    {
        public static User ToUserFromUserFormDTO(this UserRegisterFormDTO form) 
        {
            return new User()
            {
                UserName = form.UserName,
                FirstName = form.FirstName,
                LastName = form.LastName,
                Email = form.Email,
                Password = form.Password,
                BirthDate = form.BirthDate,
            };
        }

        public static User ToUserFromUserLoginDTO(this UserLoginFormDTO form) 
        {
            return new User() 
            {
                UserName = form.UserName,
                Password = form.Password,
            };
        }

        public static UserDetailsDTO ToUserDetailsDTOFromUser(this User user) 
        {
            IEnumerable<char> hidden = [];
            hidden.Append('*').Append('*').Append('*');
            return new UserDetailsDTO()
            {
                Id = user.Id,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email.Substring(0,2)+"***",
                BirthDate = user.BirthDate,
                PublishedNews = user.PublishedNews,
            };
        }
    }
}
