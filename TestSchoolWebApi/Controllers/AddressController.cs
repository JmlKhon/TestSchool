using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestSchool.Models;
using TestSchool.Models.Dtos;
using TestSchool.Repository;

namespace TestSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _repository;

        public AddressController(IAddressRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public ActionResult<int> AddAddress(AddressRequestDto addressDto)
        {
            var address = new Address
            {
                Country = addressDto.Country,
                Street = addressDto.Street,
                City = addressDto.City,
            };
            _repository.AddAddress(address);
            return address.AddressId;
        }

        [HttpGet("id")]
        public ActionResult<Address> GetAddress(int id)
        {
            return _repository.GetAddress(id);
        }

        [HttpGet]
        public ActionResult<List<Address>> GetAddresses()
        {
            return _repository.GetAddresses();
        }

        [HttpPut]
        public ActionResult<int> UpdateAddress (AddressRequestDto addressDto, int id)
        {
            var addressExist = _repository.GetAddress(id);
            var address = new Address
            {
                Country = addressDto.Country,
                Street = addressDto.Street,
                City = addressDto.City,
            };

            if (addressExist != null)
            {
                address.AddressId = addressExist.AddressId;
                _repository.UpdateAddress(address);
            }
            return id;
        }

        [HttpDelete("id")]
        public ActionResult<int> DeleteAddress(int id) 
        {
            var address =_repository.GetAddress(id);
            _repository.DeleteAddress(address);
            return id;
        }
    }
}
