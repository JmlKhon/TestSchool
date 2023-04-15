using Microsoft.EntityFrameworkCore;
using TestSchool.Models;

namespace TestSchool.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private SchoolDbContext _context;

        public StudentRepository(SchoolDbContext context)
        {
            _context = context;
        }
        public int AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return student.StudentId;
        }

        public Student GetStudent(int id) => _context.Students
            .Include(n => n.Address).FirstOrDefault(u => u.StudentId == id);

        public List<Student> GetStudents(string? searchWord, string? togriYokiTeskari)
        {
            var allStudents = _context.Students.Include(n => n.Address).ToList();
            if (!string.IsNullOrEmpty(searchWord))
            {
                allStudents = allStudents.Where(n => n.FirstName.Contains(searchWord) || n.LastName.Contains(searchWord)).ToList();
            }
            if (!string.IsNullOrEmpty(togriYokiTeskari))
            {
                if (togriYokiTeskari == "1")
                {
                    allStudents = allStudents.OrderBy(n => n.StudentId).ToList();
                }
                else if (togriYokiTeskari == "2")
                {
                    allStudents = allStudents.OrderByDescending(n => n.StudentId).ToList();
                }
                else
                {
                    throw new Exception();
                }
            }
            else allStudents = allStudents.OrderBy(n => n.StudentId).ToList();
            return allStudents;
        }

        public void UpdateStudent(Student student)
        {
            var studentExist = GetStudent(student.StudentId);

            studentExist.StudentId = student.StudentId;
            studentExist.LastName = student.LastName;
            studentExist.FirstName = student.FirstName;
            studentExist.AddressId = student.AddressId;
            _context.SaveChanges();
        }

        public void DeleteStudent(Student student)
        {
            _context.Students.Remove(student);
            _context.SaveChanges();
        }
    }
}
