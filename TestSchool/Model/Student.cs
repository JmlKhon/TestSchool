using System.ComponentModel.DataAnnotations;

namespace TestSchool.Model
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }

        public string StudentName { get; set; }

        public string StudentSureName { get; set; }

        public int StudentAddressID { get; set; }
    }
}
