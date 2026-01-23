
using Isopoh.Cryptography.Argon2;
using MilkyWayCitizen.Back.DAL.Repositories;
using MilkyWayCitizen.Back.DL.Entities;

namespace MilkyWayCitizen.Back.BLL.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        public UserService(UserRepository userRepository) 
        {
            _userRepository=userRepository;
        }
        public void Register(User user, Address address) 
        {
            if(_userRepository.GetUserByEmail(user.Email)!=null) 
            {
                throw new Exception("Email already registered.");
            }
            if(_userRepository.GetUserByUserName(user.UserName)!=null) 
            {
                throw new Exception("UserName already registered");
            }
            user.Password = Argon2.Hash(user.Password);
            _userRepository.Register(user, address);

        }
        public User Login(string username,string password) 
        {
            User? user = _userRepository.GetUserByUserName(username);
            if(user==null) 
            {
                throw new Exception("Username or password not valid.");
            }
            /*if(Argon2.Verify(user.Password, password)) 
            {
                throw new Exception("Username or password not valid.");
            }// */
            return user;
        }
        public User? GetUserById(int id) 
        {
            User? user = _userRepository.GetUserById(id);
            return user;
        }
    }
}
