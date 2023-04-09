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
        private readonly IAddressRepository _addressRepository;

        public AddressController(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        [HttpPost]
        public ActionResult<int> AddAddress(AddressRequestDto addressRequestDto)
        {
            var address = new Address
            {
                Country = addressRequestDto.Country,
                Street = addressRequestDto.Street,
                City = addressRequestDto.City,
            };
            _addressRepository.AddAddress(address);
            return address.AddressId;
        }

        [HttpGet("id")]
        public ActionResult<AddressResponseDto> GetAddress(int id)
        {
            var address = _addressRepository.GetAddress(id);
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
            var allAddresses = _addressRepository.GetAddresses();
            var allAddressesResponseDto = new List<AddressResponseDto>();

            for (int i= 0; i <= allAddresses.Count() - 1; i++)
            {
                allAddressesResponseDto.Add(new AddressResponseDto { 
                    AddressId = allAddresses[i].AddressId, Country = allAddresses[i].Country, City = allAddresses[i].City});
            }
            return allAddressesResponseDto;
        }

        [HttpPut]
        public ActionResult<int> UpdateAddress (AddressRequestDto addressRequestDto, int id)
        {
            var address = new Address
            {
                Country = addressRequestDto.Country,
                Street = addressRequestDto.Street,
                City = addressRequestDto.City,
            };

            if (_addressRepository.GetAddress(id) != null)
            {
                address.AddressId = id;
                _addressRepository.UpdateAddress(address);
            }
            return address.AddressId;
        }

        [HttpDelete("id")]
        public ActionResult<int> DeleteAddress(int id)
        {
            var address = _addressRepository.GetAddress(id);
            _addressRepository.DeleteAddress(address);
            return address.AddressId;
        }
    }
}