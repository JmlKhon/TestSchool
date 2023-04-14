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
        public ActionResult<List<List<AddressResponseDto>>> GetAddresses(string? searchWord)
        {
            try
            {
                var allAddresses = _addressRepository.GetAddresses(searchWord);
                var allAddressesResponseDto = new List<List<AddressResponseDto>>();

                for (int j = 0; j < allAddresses.Count(); j++)
                {
                    allAddressesResponseDto.Add(new List<AddressResponseDto>());
                    for (int k = 0; k < allAddresses[j].Count(); k++)
                    {
                        allAddressesResponseDto[j].Add(new AddressResponseDto
                        {
                            AddressId = allAddresses[j][k].AddressId,
                            Country = allAddresses[j][k].Country,
                            City = allAddresses[j][k].City,
                        });
                    }
                }
                return allAddressesResponseDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
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
