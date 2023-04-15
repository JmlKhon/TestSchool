using TestSchool.Models;

namespace TestSchool.Repository
{
    public interface IStudentRepository
    {
        public Student GetStudent(int id);
        public List<Student> GetStudents(string? searchWord, string? togriYokiTeskari);
        public int AddStudent(Student student);
        public void UpdateStudent(Student student);
        public void DeleteStudent(Student student);
    }
}
