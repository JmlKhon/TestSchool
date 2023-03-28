using System.ComponentModel.DataAnnotations;

namespace TestSchool.Model
{
    public class Address
    {
        [Key]
        public int AddressID { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public int HomeNumber { get; set; }

        public List<Student> student { get; set; }
    }
}
