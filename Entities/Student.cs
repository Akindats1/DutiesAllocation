using DutiesAllocationApp.Enums;

namespace DutiesAllocationApp.Entities
{
    public class Student : BaseEntity
    {
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Phone { get; set; }

        public override string ToString()
        {
            return $"{Id}\t{Code}\t{FirstName}\t{LastName}\t{Gender}\t{Phone}\t{CreatedAt}\t{ModifiedAt}";
        }

        public static Student ToStudent(string str)
        {
            var studentStr = str.Split("\t");

            var student = new Student
            {
                Id = int.Parse(studentStr[0]),
                Code = studentStr[1],
                FirstName = studentStr[2],
                LastName = studentStr[3],
                Gender = Enum.Parse<Gender>(studentStr[4]),
                Phone = studentStr[5],
                CreatedAt = DateTime.Parse(studentStr[6]),
                ModifiedAt = DateTime.Parse(studentStr[7]),
            };

            return student;
        }
    }
}