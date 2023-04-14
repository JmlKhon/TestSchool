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

        public AddressController(IAddressRepository repository)
        {
            _addressRepository = repository;
        }

        [HttpPost]
        public ActionResult<int> AddAddress(AddressRequestDto addressDto)
        {
            try
            {
                var address = new Address
                {
                    Country = addressDto.Country,
                    Street = addressDto.Street,
                    City = addressDto.City,
                };
                _addressRepository.AddAddress(address);
                return address.AddressId;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("id")]
        public ActionResult<AddressResponseDto> GetAddress(int id)
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        public ActionResult<List<AddressResponseDto>> GetAddresses(string? searchWord, string? togriYokiTeskari)
        {
            try
            {
                var allAddresses = _addressRepository.GetAddresses(searchWord, togriYokiTeskari);
                var allAddressesResponseDto = new List<AddressResponseDto>();

                for (int i = 0; i < allAddresses.Count(); i++)
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status404NotFound);
            }
        }

        [HttpPut]
        public ActionResult<int> UpdateAddress(AddressRequestDto addressDto, int id)
        {
            try
            {
                var address = new Address
                {
                    Country = addressDto.Country,
                    Street = addressDto.Street,
                    City = addressDto.City,
                };

                if (_addressRepository.GetAddress(id) != null)
                {
                    address.AddressId = id;
                    _addressRepository.UpdateAddress(address);
                }
                return id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("id")]
        public ActionResult<int> DeleteAddress(int id)
        {
            try
            {
                var address = _addressRepository.GetAddress(id);
                _addressRepository.DeleteAddress(address);
                return address.AddressId;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status204NoContent);
            }
        }
    }
}
