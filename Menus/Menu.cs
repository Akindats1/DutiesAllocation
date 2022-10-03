using DutiesAllocationApp.Entities;
using DutiesAllocationApp.Enums;
using DutiesAllocationApp.Services;
using System;
using System.IO;

namespace DutiesAllocationApp.Menus
{
    public class Menu
    {
        private static IStudentService studentService;
        private static StudentDto studentDto;
        private static UpdateStudentDto updateStudentDto; 

        public Menu()
        {
            updateStudentDto = new UpdateStudentDto();
            studentService = new StudentService();
            studentDto = new StudentDto();
        }

        public void MyMenu()
        {
            var flag = true;

            while(flag)
            {
                try
                {
                    PrintMenu();
                    Console.Write("\nPlease enter your option: ");
                    string option = Console.ReadLine();

                    switch(option)
                    {
                    
                        case "1":
                            Console.Write("Enter your student code: ");
                            var code = Console.ReadLine();

                            Console.Write("Enter your password: ");
                            var password = Console.ReadLine();

                            var student = studentService.Login(code, password);
                            if (student == null)
                            {
                                Console.WriteLine("Invalid code or password!");
                            }
                            else
                            {
                                if (student.Duty == Duty.Admin)
                                {
                                    AdminMenu();
                                }
                                else
                                {
                                    StaffMenu(student);
                                }
                            }
                            break;

                        case "#":
                            if(new FileInfo(Constants.fullPath).Length == 0)    
                            studentService.AddAdminRecord();
                            break;
                        case "0":
                            flag = false;
                            Console.WriteLine("Thank you for using our App...");
                            break;
                        default:
                            Console.WriteLine("Invalid input!");
                            break;
                    }
               
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void AdminMenu()
        {
            var flag = true;

            while (flag)
            {
                PrintAdminMenu();
                Console.Write("\nPlease enter your option: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.WriteLine("");
                        studentService.Create(studentDto);
                        Console.WriteLine("");
                        break;
                    case "2":
                        Console.WriteLine("");
                        studentService.GetAll();
                        Console.WriteLine("");
                        break;
                    case "3":
                        Console.WriteLine("");
                        Console.Write("Enter the id of student to view: ");
                        int viewId = int.Parse(Console.ReadLine());
                        studentService.GetAStudent(viewId);
                        Console.WriteLine("");
                        break;
                    case "4":
                        Console.WriteLine("");
                        Console.Write("Enter student Id to update: ");
                        int id = int.Parse(Console.ReadLine());
                        studentService.Update(id, updateStudentDto);
                        Console.WriteLine("");
                        break;
                    case "5":
                        Console.WriteLine("");
                        Console.Write("Enter the id of student to delete: ");
                        int empId = int.Parse(Console.ReadLine());
                        studentService.Delete(empId);
                        Console.WriteLine("");
                        break;
                    case "0":
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input!");
                        break;
                }
            }
        }

        public void StaffMenu(Student student)
        {
            var flag = true;

            while (flag)
            {
                PrintStudentMenu();
                Console.Write("\nPlease enter your option: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.WriteLine("");
                        studentService.PrintDetailView(student);
                        Console.WriteLine("");
                        break;
                    case "2":
                        Console.WriteLine("");
                        studentService.Update(student.Code, updateStudentDto);
                        Console.WriteLine("");
                        break;

                    case "3":
                        Console.WriteLine("");
                        Console.Write("Enter your old password: ");
                        var oldPassword = Console.ReadLine();
                        Console.Write("Enter your new password: ");
                        var newPassword = Console.ReadLine();
                        Console.Write("Confirm your password: ");
                        var confirmPassword = Console.ReadLine();
                        studentService.ChangePassword(student.Code, oldPassword, newPassword, confirmPassword);
                        Console.WriteLine("");
                        break;
                    case "0":
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input!");
                        break;
                }
            }
        }

        public void PrintMenu()
        {
            if (new FileInfo(Constants.fullPath).Length == 0)
            {
                Console.WriteLine("Enter # to seed admin data");
            }
            if(new FileInfo(Constants.fullPath).Length > 0)
            {
                Console.WriteLine("Enter 1 to login.");
            }
            Console.WriteLine("Enter 0 to exit.");
        }

        public void PrintAdminMenu()
        {
            Console.WriteLine("Enter 1 to add new Student.");
            Console.WriteLine("Enter 2 to view all students.");
            Console.WriteLine("Enter 3 to view a student.");
            Console.WriteLine("Enter 4 to update a student.");
            Console.WriteLine("Enter 5 to delete a student.");
            Console.WriteLine("Enter 0 to go back to main menu.");
        }

        public void PrintStudentMenu()
        {
            Console.WriteLine("Enter 1 to view your details.");
            Console.WriteLine("Enter 2 to edit your profile.");
            Console.WriteLine("Enter 3 to change your password.");
            Console.WriteLine("Enter 0 to go back to main menu.");
        }
    }
}