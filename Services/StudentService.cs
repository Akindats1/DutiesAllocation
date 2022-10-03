using DutiesAllocationApp.Entities;
using DutiesAllocationApp.Enums;
using DutiesAllocationApp.Repository;
using DutiesAllocationApp.Shared;


using System;


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
            request.Password = request.LastName;

            int duty = Helper.SelectEnum("Enter student duty: \nEnter 1 for Admin\nEnter 2 for Dinning\nEnter 3 for Kitchen\nEnter 4 for Surrounding\nEnter 5 for Toilet\nEnter 6 for SadrofficeAndMosque\nEnter 7 for Classroom\nEnter 8 for CorridorAndStaircase\nEnter 9 for Supervision : ", 1, 9);
            request.Duty = (Duty)duty;

            int gender = Helper.SelectEnum("Enter student gender:\nEnter 1 for Male\nEnter 2 for Female\nEnter 3 for RatherNotSay: ", 1, 3);
            request.Gender = (Gender)gender;

            var student = new Student
            {
                Id = id,
                Code = code,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Phone = request.Phone,
                Password = request.Password,
                Duty = request.Duty,
                Gender = request.Gender,
                Date = date
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

            

            int newDuty = Helper.SelectEnum("Enter student duty: \nEnter 1 for Admin\nEnter 2 for Dinning\nEnter 3 for Kitchen\nEnter 4 for Surrounding\nEnter 5 for Toilet\nEnter 6 for SadrofficeAndMosque\nEnter 7 for Classroom\nEnter 8 for CorridorAndStaircase\n Enter 9 for Supervision : ", 1, 9);
            updateStudentDto.Duty = (Duty)newDuty;

            int newGender = Helper.SelectEnum("Enter student gender: \nEnter 1 for Male\nEnter 2 for Female\nEnter 3for RatherNotSay: ", 1, 3);
            updateStudentDto.Gender = (Gender)newGender;

            if (student != null)
            {
                student.FirstName = updateStudentDto.FirstName;
                student.LastName = updateStudentDto.LastName;
                student.Gender = updateStudentDto.Gender;
                student.Duty = updateStudentDto.Duty;
                student.Phone = updateStudentDto.Phone;
                

                if(student.Id == 1)
                {
                    student.Duty = Duty.Admin;
                }

                studentRepository.RefreshFile();

                Console.WriteLine($"Student record with code \"{student.Code}\" is successfully updated!");
            }
            else
            {
                Console.WriteLine($"Student not found!");
            }
        }

        public void Update(string code, UpdateStudentDto updateStudentDto)
        {
            var student = studentRepository.GetByCode(code);

            Console.Write("Enter student firstname: ");
            updateStudentDto.FirstName = Console.ReadLine();

            Console.Write("Enter student lastname: ");
            updateStudentDto.LastName = Console.ReadLine();

            Console.Write("Enter student phone: ");
            updateStudentDto.Phone = Console.ReadLine();

            

            if (student != null)
            {
                student.FirstName = updateStudentDto.FirstName;
                student.LastName = updateStudentDto.LastName;
                student.Phone = updateStudentDto.Phone;
               

                studentRepository.RefreshFile();

                Console.WriteLine("Record updated successfully!");
            }
            else
            {
                Console.WriteLine("An error occured!");
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
            Console.WriteLine($"Student Code: {student.Code}\tFullname: {student.LastName} {student.FirstName}\tGender: {student.Gender}\tDuty: {student.Duty}...");
        }

        public void PrintDetailView(Student student)
        {
            Console.WriteLine($"Code: {student.Code}\nFullname: {student.LastName} {student.FirstName}\nPhone: {student.Phone}\nDuty: {student.Duty}\nGender: {student.Gender}\nDate: {student.Date}");
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

        public void ChangePassword(string code, string oldPassword, string newPassword, string confirmPassword)
        {
            var student = studentRepository.GetByCode(code);

            if (student == null)
            {
               Console.WriteLine($"Student with the code: {code} not found");
               return;
            }

            if (student.Password != oldPassword)
            {
               Console.WriteLine("Invalid code or password!");
               return;
            }
            if(newPassword !=  confirmPassword)
            {
                Console.WriteLine("Password mismatch");
                return;
            }

            student.Password = newPassword;
            studentRepository.RefreshFile();
            Console.WriteLine("You successfully changed your password!");
        }

        public Student Login(string code, string password)
        {
            var student = studentRepository.GetByCode(code);

            if (student != null && student.Password == password)
            {
                return student;
            }

            return null;
        }

        public void AddAdminRecord()
        {
            var e = new Student
            {
                Id = 1,
                Code = Helper.GenerateCode(1),
                FirstName = "Abdulrasheed",
                LastName = "Bello",
                Password = "admin",
                Phone = "09074866640",
                Gender = Gender.Male,
                Duty = Duty.Admin,
                Date = DateTime.Now



            };
            StudentRepository.students.Add(e);
            studentRepository.WriteToFile(e);
        }

        
    }
}