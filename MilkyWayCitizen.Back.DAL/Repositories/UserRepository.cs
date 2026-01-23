
using Microsoft.EntityFrameworkCore;
using MilkyWayCitizen.Back.DAL.Contexts;
using MilkyWayCitizen.Back.DL.Entities;

namespace MilkyWayCitizen.Back.DAL.Repositories
{
    public class UserRepository
    {
        private readonly DbSet<User> _users;
        private readonly DbSet<Address> _addresses;
        private readonly MilkyWayContext _milkyWay;
        public UserRepository(MilkyWayContext context) 
        {
            _milkyWay=context;
            _users=context.Users;
            _addresses=context.Addresses;
        }
        public void Register(User user, Address address) 
        {
            _users.Add(user);
            _milkyWay.SaveChanges();
            int userId = GetUserByEmail(user.Email)!.Id;
            address.UserID = userId;
            _addresses.Add(address);
            _milkyWay.SaveChanges();
            user.AddressID=GetAddressIdByUserId(userId);
            _users.Update(user);
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
            User? user = _users.FirstOrDefault(y => y.Email == Email);
            if(user!=null)
            {
                user=AddAddressToUser(user);
            }
            return user;
        }
        public User? GetUserByUserName(string userName) 
        {
            User? user = _users.FirstOrDefault(y => y.UserName==userName);
            if(user!=null) 
            {
                user = AddAddressToUser(user);
            }
            return user;
        }
        public User? GetUserById(int id) 
        {
            User? user = _users.FirstOrDefault(y => y.Id==id);
            if(user!=null)
            {
                user=AddAddressToUser(user);
            }
            return user;
        }

        public User AddAddressToUser(User user) 
        {
            Address? address = _addresses.FirstOrDefault(y => y.UserID==user.Id);
            Console.WriteLine("UserId + "+user.Id);
            if(/*user.Address==null && */address!=null) 
            {
                Console.WriteLine("AddressId + " + address.ID);
                user.Address=address;       //  The mapper is rewriting over this instruction.
                //user.Address.StreetNumber=address.StreetNumber;
                //user.Address.StreetName=address.StreetName;
                //user.Address.City=address.City;
                //user.Address.Contry=address.Contry;
                user.AddressID=address.ID;
            }
            return user;
        }
        public int GetAddressIdByUserId(int userId) 
        {
            Address? address = _addresses.FirstOrDefault(y => y.UserID==userId);
            int id = 0;
            if(address is not null) 
            {
                id=address.ID;
            }
            return id;
        }
    }
}
