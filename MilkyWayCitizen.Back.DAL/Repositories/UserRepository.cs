using Microsoft.EntityFrameworkCore;
using MilkyWayCitizen.Back.DAL.Contexts;
using MilkyWayCitizen.Back.DL.Entities;

namespace MilkyWayCitizen.Back.DAL.Repositories
{
    public class UserRepository
    {
        private readonly DbSet<User> _users;
        private readonly MilkyWayContext _milkyWay;
        public UserRepository(MilkyWayContext context) 
        {
            _users=context.Users;
            _milkyWay=context;
        }
        public void Register(User user) 
        {
            _users.Add(user);
            _milkyWay.SaveChanges();
        }
        public bool IsUserUnique(string Email,string UserName) 
        {
            bool unicity = false;
            if(_users.FirstOrDefault(y => y.Email==Email||y.UserName==UserName) is null) 
            {
                unicity = true;
            }
            return unicity;
        }
        public User? GetUserByEmail(string Email)
        {
            return _users.FirstOrDefault(y => y.Email == Email);
        }
        public User? GetUserByUserName(string userName) 
        {
            return _users.FirstOrDefault(y => y.UserName == userName);
        }
        public User? GetUserById(int id) 
        {
            return _users.FirstOrDefault(y => y.Id == id);
        }
    }
}
