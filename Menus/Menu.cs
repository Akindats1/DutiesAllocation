using DutiesAllocation.Entities.Dto;
using DutiesAllocationApp.Entities;
using DutiesAllocationApp.Enums;
using DutiesAllocationApp.Services;
using DutiesAllocationApp.Services.Contracts;
using System;
using System.IO;

namespace DutiesAllocationApp.Menus
{
    public class Menu
    {
        private static IStudentService studentService;
        private static IDutyService dutyService;
        private static StudentDto studentDto;
        private static UpdateStudentDto updateStudentDto;
        private static DutyDto dutyDto;

        public Menu()
        {
            studentService = new StudentService();
            studentDto = new StudentDto();
            updateStudentDto = new UpdateStudentDto();
            dutyService = new DutyService();
            dutyDto = new DutyDto();
        }

        public void MyMenu()
        {
            var flag = true;

            while (flag)
            {
                try
                {
                    PrintMenu();
                    Console.Write("\nPlease enter your option: ");
                    string option = Console.ReadLine();

                    switch (option)
                    {
                        case "1":
                            StudentMenu();
                            break;
                        case "2":
                            DutyMenu();
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
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void StudentMenu()
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
                        studentService.Create(studentDto);
                        Console.WriteLine("");
                        break;
                    case "2":
                        Console.WriteLine("");
                        Console.WriteLine("Enter duty id: ");
                        int dutyId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter student id: ");
                        int studentId = int.Parse(Console.ReadLine());
                        studentService.AssignDutyToStudent(dutyId, studentId);
                        Console.WriteLine("");
                        break;
                    case "3":
                        Console.WriteLine("");
                        studentService.GetAll();
                        Console.WriteLine("");
                        break;
                    case "4":
                        Console.WriteLine("");
                        Console.Write("Enter the id of student to view: ");
                        int viewId = int.Parse(Console.ReadLine());
                        studentService.GetAStudent(viewId);
                        Console.WriteLine("");
                        break;
                    case "5":
                        Console.WriteLine("");
                        Console.Write("Enter student Id to update: ");
                        int id = int.Parse(Console.ReadLine());
                        studentService.Update(id, updateStudentDto);
                        Console.WriteLine("");
                        break;
                    case "6":
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

        public void DutyMenu()
        {
            var flag = true;

            while (flag)
            {
                PrintDutyMenu();
                Console.Write("\nPlease enter your option: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.WriteLine("");
                        dutyService.Create(dutyDto);
                        Console.WriteLine("");
                        break;
                    case "2":
                        Console.WriteLine("");
                        dutyService.GetAll();
                        Console.WriteLine("");
                        break;
                    case "3":
                        Console.WriteLine("");
                        Console.Write("Enter duty Id to update: ");
                        int id = int.Parse(Console.ReadLine());
                        dutyService.Update(id, dutyDto);
                        Console.WriteLine("");
                        break;
                    case "4":
                        Console.WriteLine("");
                        Console.Write("Enter the id of duty to delete: ");
                        int dutyId = int.Parse(Console.ReadLine());
                        dutyService.Delete(dutyId);
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
            Console.WriteLine("Enter 1 to view student menu.");
            Console.WriteLine("Enter 2 to view duty menu.");
            Console.WriteLine("Enter 0 to exit.");
        }

        public void PrintStudentMenu()
        {
            Console.WriteLine("Enter 1 to add new Student.");
            Console.WriteLine("Enter 2 to assign duty to Student.");
            Console.WriteLine("Enter 3 to view all students.");
            Console.WriteLine("Enter 4 to view a student.");
            Console.WriteLine("Enter 5 to update a student.");
            Console.WriteLine("Enter 6 to delete a student.");
            Console.WriteLine("Enter 0 to go back to main menu.");
        }

        public void PrintDutyMenu()
        {
            Console.WriteLine("Enter 1 to create new duty.");
            Console.WriteLine("Enter 2 to view all duty.");
            Console.WriteLine("Enter 3 to update duty.");
            Console.WriteLine("Enter 4 to delete duty.");
            Console.WriteLine("Enter 0 to go back to main menu.");
        }
    }
}