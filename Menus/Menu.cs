using DutiesAllocation.Entities.Dto;
using DutiesAllocationApp.Entities;
using DutiesAllocationApp.Entities.Dto;
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
        private static DutyAssignmentDto dutyAssignmentDto;
        private static IDutyAssignmentService dutyAssignmentService;


        public Menu()
        {
            studentService = new StudentService();
            studentDto = new StudentDto();
            updateStudentDto = new UpdateStudentDto();
            dutyService = new DutyService();
            dutyDto = new DutyDto();
            dutyAssignmentDto = new DutyAssignmentDto(); 
            dutyAssignmentService = new DutyAssignmentService();
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
                        case"3": 
                            DutyAssignmentMenu();
                            break ;
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
                        studentService.GetAll();
                        Console.WriteLine("");
                        break;
                    case "3":
                        Console.WriteLine("");
                        Console.WriteLine("Enter the id of the student to view");
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


        public void DutyAssignmentMenu()
        {
            var flag = true;

            while (flag)
            {
                PrintDutyAssignmentMenu();
                Console.Write("\nPlease enter your option: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.WriteLine("");
                        dutyAssignmentService.AssignDutyTostudent(dutyAssignmentDto);
                        Console.WriteLine("");
                        break;
                    case "2":
                        Console.WriteLine("");
                        dutyAssignmentService.ViewAllDutyToStudent();
                        Console.WriteLine("");
                        break;
                    case "3":
                        Console.WriteLine("");
                        Console.Write("Enter student code: ");
                        string inputCode = Console.ReadLine();
                        dutyAssignmentService.DeleteDutyToStudent(inputCode);
                        Console.WriteLine("");
                        break;
                    case "4":
                        Console.WriteLine("");
                        Console.Write("Enter duty assignment id to update: ");
                        int id = int.Parse(Console.ReadLine());
                        dutyAssignmentService.UpdateDutyToStudent(id, dutyAssignmentDto);
                        Console.WriteLine("");
                        break;
                    case "5":
                        Console.WriteLine("");
                        Console.Write("Enter the name of duty to view: ");
                        string viewDuty = Console.ReadLine();
                        dutyAssignmentService.ViewDutyToAStudent(viewDuty);
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
            Console.WriteLine("Enter 3 to view duty assignment menu.");
            Console.WriteLine("Enter 0 to exit.");
        }

        public void PrintStudentMenu()
        {
            Console.WriteLine("Enter 1 to add new Student.");
            Console.WriteLine("Enter 2 to view all students.");
            Console.WriteLine("Enter 3 to view a student.");
            Console.WriteLine("Enter 4 to update a student.");
            Console.WriteLine("Enter 5 to delete a student.");
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

        public void PrintDutyAssignmentMenu()
        {
            Console.WriteLine("Enter 1 to assign duty to student");
            Console.WriteLine("Enter 2 to view duties to students");
            Console.WriteLine("Enter 3 to delete duty to student");
            Console.WriteLine("Enter 4 to update duty to student");
            Console.WriteLine("Enter 5 to view duty to student");
            Console.WriteLine("Enter 0 to go back to the main menu");

        }
    }
}