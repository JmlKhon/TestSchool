using Microsoft.EntityFrameworkCore;
using TestSchool.Models;

namespace TestSchool.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private SchoolDbContext _context;
        public AddressRepository(SchoolDbContext context)
        {
            _context = context;
        }

        public int AddAddress(Address address)
        {
            _context.Address.Add(address);
            _context.SaveChanges();
            return address.AddressId;
        }

        public Address GetAddress(int id) => _context.Address
            .Include(n => n.Students).FirstOrDefault(u => u.AddressId == id);

        public List<Address> GetAddresses(string? searchWord)
        {
            var allAddresses = _context.Addres.Include(n => n.Students).ToList();
            if(!string.IsNullOrEmpty(searchWord) )
            {
                allAddresses = allAddresses.Where(n => n.Country.Contains(searchWord)).ToList();
            }
            var sortingAllAddresses = allAddresses.OrderBy(n => n.Country);
            return sortingAllAddresses.ToList();
        }

        public void UpdateAddress(Address address)
        {
            var AddressExist = GetAddress(address.AddressId);

            AddressExist.AddressId = address.AddressId;
            AddressExist.City = address.City;
            AddressExist.Country = address.Country;
            AddressExist.Street = address.Street;
            _context.SaveChanges();
        }

        public void DeleteAddress(Address address)
        {
            _context.Address.Remove(address);
            _context.SaveChanges();
        }
    }
}
