using ConsoleTables;
using DutiesAllocation.Entities.Dto;
using DutiesAllocationApp.Entities;
using DutiesAllocationApp.Enums;
using DutiesAllocationApp.Repository;
using DutiesAllocationApp.Repository.Contracts;
using DutiesAllocationApp.Services.Contracts;
using DutiesAllocationApp.Shared;

namespace DutiesAllocationApp.Services
{
    public class StudentService : IStudentService
    {
        private static IStudentRepository studentRepository;


        public StudentService()
        {
            studentRepository = new StudentRepository();
        }

        public void Create(StudentDto request)
        {
            var students = studentRepository.GetAll();

            int id = (students.Count != 0) ? students[students.Count - 1].Id + 1 : 1;
            string code = Helper.GenerateCode(id);

            Console.Write("Enter student firstname: ");
            request.FirstName = Console.ReadLine();

            Console.Write("Enter student lastname: ");
            request.LastName = Console.ReadLine();

            Console.Write("Enter student phone number: ");
            request.Phone = Console.ReadLine();

            int gender = Helper.SelectEnum("Enter student gender:\nEnter 1 for Male\nEnter 2 for Female\nEnter 3 for RatherNotSay: ", 1, 3);
            request.Gender = (Gender)gender;

            var student = new Student
            {
                Id = id,
                Code = code,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Phone = request.Phone,
                Gender = request.Gender,
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = new DateTime(0001, 01, 01)
            };

            var findStudent = studentRepository.GetByIdOrCode(student.Id, student.Code);


            if (findStudent == null)
            {
                students.Add(student);
                studentRepository.WriteToFile(student);
                Console.WriteLine($"New student with code \"{student.Code}\" created successfully!");

            }
            else
            {
                Console.WriteLine($"student with {student.Code} already exist!");
            }
        }

        public void Update(int id, UpdateStudentDto updateStudentDto)
        {
            var student = studentRepository.GetById(id);

            if (student != null)
            {
                Console.Write("Enter student firstname: ");
                updateStudentDto.FirstName = Console.ReadLine();

                Console.Write("Enter student lastname: ");
                updateStudentDto.LastName = Console.ReadLine();

                Console.Write("Enter student phone: ");
                updateStudentDto.Phone = Console.ReadLine();

                int newGender = Helper.SelectEnum("Enter student gender: \nEnter 1 for Male\nEnter 2 for Female\nEnter 3 for RatherNotSay: ", 1, 3);
                updateStudentDto.Gender = (Gender)newGender;

                student.FirstName = updateStudentDto.FirstName;
                student.LastName = updateStudentDto.LastName;
                student.Gender = updateStudentDto.Gender;
                student.Phone = updateStudentDto.Phone;
                student.ModifiedAt = DateTime.UtcNow;

                studentRepository.RefreshFile();

                Console.WriteLine($"Student record with code \"{student.Code}\" is successfully updated!");
            }
            else
            {
                Console.WriteLine($"Student not found!");
            }
        }

        public void Delete(int id)
        {
            try
            {
                var student = studentRepository.GetById(id);
                var students = studentRepository.GetAll();

                if (student == null)
                {
                    Console.WriteLine($"Student with the id: {id} not found");
                    return;
                }

                students.Remove(student);
                studentRepository.RefreshFile();
                Console.WriteLine($"Student with the id: {id} successfully deleted.");

            }
            catch (Exception ex)
            {
                Console.Write($"Something went wrong:{ex.Message}");
            }
        }

        public void GetAll()
        {
            var students = studentRepository.GetAll();
            var table = new ConsoleTable("Student Code", "First Name", "Last Name","Gender", "Phone", "Created", "Modified");

            if (students.Count  != 0)
            {
                foreach (var student in students)
                {
                    table.AddRow(student.Code, student.FirstName, student.LastName, student.Gender, student.Phone, student.CreatedAt, student.ModifiedAt);            
                }
                table.Write(Format.Alternative);
                return;
            }

          
        }
        public void GetAStudent(int id)
        {
            var student = studentRepository.GetById(id);
            var table = new ConsoleTable("Student Code", "First Name", "Last Name", "Gender", "Phone", "Created", "Modified");

            if (student != null)
            {
                table.AddRow(student.Code, student.FirstName, student.LastName, student.Gender, student.Phone, student.CreatedAt, student.ModifiedAt);
                table.Write(Format.MarkDown);
                return;
            }
            
            Console.WriteLine("Student not found!");
        }
    }
}