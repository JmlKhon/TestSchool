namespace TestSchool.Models.Dtos
{
    public class AddressRequestDto
    {
        public int AddressId {get; set;}
        
        public string Country { get; set; }

        public string City { get; set; }
        
        public string Street { get; set; }
    }
}
