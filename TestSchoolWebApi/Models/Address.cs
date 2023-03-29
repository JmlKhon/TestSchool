namespace TestSchool.Models
{
    public class Address
    {
        public int AddressId { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
