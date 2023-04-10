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
        public ActionResult<AddressResponseDto> GetAddress(int id)
        { 
            var address = _repository.GetAddress(id);
            var addressResponseDto = new AddressResponseDto
            {
                AddressId = address.AddressId,
                Country = address.Country,
                City = address.City,
            };
            return addressResponseDto;
        }

        [HttpGet]
        public ActionResult<List<AddressResponseDto>> GetAddresses()
        {
            var allAddresses = _repository.GetAddresses();
            var allAddressesResponseDto = new List<AddressResponseDto>();

            for (int i = 0; i <= allAddresses.Count() - 1; i++)
            {
                allAddressesResponseDto.Add(new AddressResponseDto
                {
                    AddressId = allAddresses[i].AddressId,
                    Country = allAddresses[i].Country,
                    City = allAddresses[i].City
                });
            }
            return allAddressesResponseDto;
        }

        [HttpPut]
        public ActionResult<int> UpdateAddress (AddressRequestDto addressDto, int id)
        {
            var address = new Address
            {
                Country = addressDto.Country,
                Street = addressDto.Street,
                City = addressDto.City,
            };

            if (_repository.GetAddress(id) != null)
            {
                address.AddressId = id;
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
