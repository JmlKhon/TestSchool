using Microsoft.AspNetCore.Http;
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

        [HttpGet("id")]
        public ActionResult<Student> GetStudent(int id)
        {
            return _studentRepository.GetStudent(id);
        }

        [HttpGet]
        public ActionResult<List<Student>> GetStudents() 
        {
            return _studentRepository.GetStudents();
        }

        [HttpPost]
        public ActionResult<int> UpdateStudent(StudentRequestDto studentRequestDto,int id) 
        {
            var studentExist = _studentRepository.GetStudent(id);
            var student = new Student
            {
                FirstName = studentRequestDto.FirstName,
                LastName = studentRequestDto.LastName,
                Email = studentRequestDto.Email,
                Phone = studentRequestDto.Phone,
                AddressId = studentRequestDto.AdressId,
            };
            if (studentExist != null)
            {
                student.StudentId = studentExist.StudentId;
                _studentRepository.UpdateStudent(student);
            }
            return id;
        }

        [HttpDelete("id")]
        public ActionResult<int> DeleteStudent(int id)
        {
            var student= _studentRepository.GetStudent(id);
            _studentRepository.DeleteStudent(student);
            return id;
        }
    }
}
