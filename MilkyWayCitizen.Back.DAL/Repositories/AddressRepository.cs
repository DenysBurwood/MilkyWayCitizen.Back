
using Microsoft.EntityFrameworkCore;
using MilkyWayCitizen.Back.DAL.Contexts;
using MilkyWayCitizen.Back.DL.Entities;

namespace MilkyWayCitizen.Back.DAL.Repositories
{
    public class AddressRepository
    {
        private readonly DbSet<Address> _addresses;
        private readonly MilkyWayContext _context;

        public AddressRepository(MilkyWayContext context) 
        {
            _context = context;
            _addresses=context.Addresses;
        }

        public void Add(Address address) 
        {
            _addresses.Add(address);
            _context.SaveChanges();
        }
    }
}
