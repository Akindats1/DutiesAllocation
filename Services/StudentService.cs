using DutiesAllocation.Entities.Dto;
using DutiesAllocationApp.Entities;
using DutiesAllocationApp.Enums;
using DutiesAllocationApp.Repository;
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
            DateTime date = DateTime.Now;

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
                CreatedAt = DateTime.UtcNow
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

            Console.Write("Enter student firstname: ");
            updateStudentDto.FirstName = Console.ReadLine();

            Console.Write("Enter student lastname: ");
            updateStudentDto.LastName = Console.ReadLine();
            
            Console.Write("Enter student phone: ");
            updateStudentDto.Phone = Console.ReadLine();

            int newGender = Helper.SelectEnum("Enter student gender: \nEnter 1 for Male\nEnter 2 for Female\nEnter 3for RatherNotSay: ", 1, 3);
            updateStudentDto.Gender = (Gender)newGender;

            if (student != null)
            {
                student.FirstName = updateStudentDto.FirstName;
                student.LastName = updateStudentDto.LastName;
                student.Gender = updateStudentDto.Gender;
                student.Phone = updateStudentDto.Phone;

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
                }

                if (student.Id == 1)
                {
                    Console.WriteLine($"Record cannot be deleted!");
                }
                else
                {
                    students.Remove(student);
                    studentRepository.RefreshFile();
                    Console.WriteLine($"Student with the id: {id} successfully deleted.");
                }
            }
            catch (Exception ex)
            {
                Console.Write($"Something went wrong:{ex.Message}");
            }
        }

        public void PrintListView(Student student)
        {
            Console.WriteLine($"Student Code: {student.Code}\tFullname: {student.LastName} {student.FirstName}\tGender: {student.Gender}");
        }

        public void PrintDetailView(Student student)
        {
            Console.WriteLine($"Code: {student.Code}\nFullname: {student.LastName} {student.FirstName}\nPhone: {student.Phone}\nGender: {student.Gender}\nDate: {student.CreatedAt}");
        }

        public void GetAll()
        {
            var students = studentRepository.GetAll();

            foreach (var student in students)
            {
                PrintListView(student);
            }
        }

        public void GetAStudent(int id)
        {
            var student = studentRepository.GetById(id);

            if(student != null)
            {
                PrintDetailView(student);
            }
            else
            {
                Console.WriteLine("Student not found!");
            }
        }
        
    }
}