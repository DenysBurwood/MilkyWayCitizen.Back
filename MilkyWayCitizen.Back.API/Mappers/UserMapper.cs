using MilkyWayCitizen.Back.API.DTOs;
using MilkyWayCitizen.Back.API.Tools;
using MilkyWayCitizen.Back.DL.Entities;

namespace MilkyWayCitizen.Back.API.Mappers
{
    public static class UserMapper
    {
        public static User ToUserFromUserRegisterDTO(this UserRegisterFormDTO form) 
        {
            return new User()
            {
                UserName = form.UserName,
                FirstName = form.FirstName,
                LastName = form.LastName,
                Email = form.Email,
                Password = form.Password,
                BirthDate = form.BirthDate.DateTimeToDateOnly(),
            };
        }
        public static Address ToAddressFromUserRegisterDTO(this UserRegisterFormDTO form) 
        {
            return new Address()
            {
                StreetName = form.StreetName,
                StreetNumber = form.StreetNumber,
                City = form.City,
                Contry = form.Country,
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
                Role = user.Role,
                Address = new Address() 
                {
                    StreetName = user.Address.StreetName,
                    StreetNumber = user.Address.StreetNumber,
                    City = user.Address.City,
                    Contry = user.Address.Contry,
                },
                AddressID = user.AddressID,
            };
        }

        public static UserArchive FromUserToUserArchive(this User user) 
        {
            return new UserArchive() 
            {
                Id=user.Id,
                UserName=user.UserName,
                FirstName=user.FirstName,
                LastName=user.LastName,
                Email = user.Email,
                BirthDate=user.BirthDate
            };
        }
    }
}
