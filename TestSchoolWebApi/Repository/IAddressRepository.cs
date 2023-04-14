using TestSchool.Models;

namespace TestSchool.Repository
{
    public interface IAddressRepository
    {
        public Address GetAddress(int id);
        public List<List<Address>> GetAddresses(string? searchWord);
        public int AddAddress(Address address);
        public void UpdateAddress(Address address);
        public void DeleteAddress(Address address);
    }
}
