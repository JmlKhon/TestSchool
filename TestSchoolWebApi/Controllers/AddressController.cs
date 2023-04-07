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
            try
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
            catch (Exception ex)
            {
                // exception ni registratsiya qilish
                // xato xaqida malumot beradi
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Address> GetAddress(int id)
        {
            try
            {
                var address = _repository.GetAddress(id);

                if (address == null)
                {
                    return NotFound();
                }

                return address;
            }
            catch (Exception ex)
            {
                // exception ni registratsiya qilish
                // xato xaqida malumot beradi
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]

        public ActionResult<List<Address>> GetAddresses()
        {
            try
            {
                return _repository.GetAddresses();
            }
            catch (Exception ex)
            {
                // exception ni registratsiya qilish
                // xato xaqida malumot beradi
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpPut]
        public ActionResult<int> UpdateAddress(AddressRequestDto addressDto, int id)
        {
            try
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
            catch (Exception ex)
            {
                // exception ni registratsiya qilish
                // xato xaqida malumot beradi
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<int> DeleteAddress(int id)
        {
            try
            {
                var address = _repository.GetAddress(id);
                _repository.DeleteAddress(address);
                return id;
            }
            catch (Exception ex)
            {
                // exception ni registratsiya qilish
                // xato xaqida malumot beradi
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
