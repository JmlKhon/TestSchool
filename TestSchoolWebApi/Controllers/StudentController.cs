using Microsoft.AspNetCore.Mvc;
using TestSchool.Models;
using TestSchool.Models.Dtos;
using TestSchool.Repository;

namespace TestSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpPost]
        public ActionResult<int> AddStudent(StudentRequestDto studentRequestDto)
        {
            try
            {
                var student = new Student
                {
                    FirstName = studentRequestDto.FirstName,
                    LastName = studentRequestDto.LastName,
                    Email = studentRequestDto.Email,
                    Phone = studentRequestDto.Phone,
                    AddressId = studentRequestDto.AdressId,
                };
                _studentRepository.AddStudent(student);
                return student.StudentId;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("id")]
        public ActionResult<StudentResponseDto> GetStudent(int id)
        {
            try
            {
                var student = _studentRepository.GetStudent(id);
                var studentResponseDto = new StudentResponseDto
                {
                    StudentId = student.StudentId,
                    StudentName = ($"{student.FirstName} {student.LastName}"),
                    Address = ($"{student.Address.Country} {student.Address.City}"),
                };
                return studentResponseDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        public ActionResult<List<StudentResponseDto>> GetStudents(string? searchWord, string? togriYokiTeskari)
        {
            try
            {
                var allStudents = _studentRepository.GetStudents(searchWord, togriYokiTeskari);
                var allStudentsResponseDto = new List<StudentResponseDto>();

                for (int i = 0; i <= allStudents.Count() - 1; i++)
                {
                    allStudentsResponseDto.Add(new StudentResponseDto
                    {
                        StudentId = allStudents[i].StudentId,
                        StudentName = ($"{allStudents[i].FirstName} {allStudents[i].LastName}"),
                        Address = ($"{allStudents[i].Address.Country} {allStudents[i].Address.City}")
                    });
                }
                return allStudentsResponseDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status404NotFound);
            }
        }

        [HttpPut]
        public ActionResult<int> UpdateStudent(StudentRequestDto studentRequestDto, int id)
        {
            try
            {
                var student = new Student
                {
                    FirstName = studentRequestDto.FirstName,
                    LastName = studentRequestDto.LastName,
                    Email = studentRequestDto.Email,
                    Phone = studentRequestDto.Phone,
                    AddressId = studentRequestDto.AdressId,
                };
                if (_studentRepository.GetStudent(id) != null)
                {
                    student.StudentId = id;
                    _studentRepository.UpdateStudent(student);
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
        public ActionResult<int> DeleteStudent(int id)
        {
            try
            {
                var student = _studentRepository.GetStudent(id);
                _studentRepository.DeleteStudent(student);
                return student.StudentId;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status204NoContent);
            }
        }
    }
}
