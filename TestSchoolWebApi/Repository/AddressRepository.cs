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

        public Address GetAddress(int id)
        {
            return _context.Address.FirstOrDefault(u => u.AddressId == id);
        }

        public List<Address> GetAddresses()
        {
            return _context.Address.ToList();
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
