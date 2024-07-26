using ConsoleTables;
using DutiesAllocation.Repository;
using DutiesAllocationApp.Entities;
using DutiesAllocationApp.Entities.Dto;
using DutiesAllocationApp.Repository;
using DutiesAllocationApp.Repository.Contracts;
using DutiesAllocationApp.Services.Contracts;

namespace DutiesAllocationApp.Services
{
    public class DutyAssignmentService : IDutyAssignmentService
    {
        private IDutyRepository dutyRepository;
        private IStudentRepository studentRepository;
        private IDutyAssignmentRepository dutyAssignmentRepository;

        public DutyAssignmentService()
        {
            dutyRepository = new DutyRepository();
            studentRepository = new StudentRepository();
            dutyAssignmentRepository = new DutyAssignmentRepository();
        }
        public void AssignDutyTostudent(DutyAssignmentDto request)
        {
            var dutiesAssignment = dutyAssignmentRepository.GetDutyAssignments();
            int id = (dutiesAssignment.Count != 0) ? dutiesAssignment[dutiesAssignment.Count - 1].Id + 1 : 1;
            Console.WriteLine("Enter duty id: ");
            int dutyId = request.DutyId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter student code: ");
            string studentCode = request.StudentCode = Console.ReadLine();

            var student = studentRepository.GetByCode(studentCode);
            var duty = dutyRepository.GetById(dutyId);
            var studentAssignmentCode = dutyAssignmentRepository.GetDutyAssignmentByStudentCode(studentCode);


            var dutyAssign = new DutyAssignment
            {
                Id = id,
                StudentCode = studentCode,
                DutyName = duty.DutyName,
                StudentName = $"{student.FirstName} {student.LastName}",
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = new DateTime(01, 01, 0001)

            };

            if (duty == null || student == null)
            {
                Console.WriteLine("Student or duty does not exist");
                return;
            }

            if (studentAssignmentCode == null)
            {
                dutiesAssignment.Add(dutyAssign);
                dutyAssignmentRepository.WriteToFile(dutyAssign);
                Console.WriteLine($"{duty.DutyName} duty has been assigned to {student.LastName} {student.FirstName}");
                return;

            }

            Console.WriteLine($"{studentAssignmentCode.DutyName} duty already assigned to {studentAssignmentCode.StudentName}");
        }

        public void DeleteDutyToStudent(string code)
        {
            try
            {

                var dutyAssignment = dutyAssignmentRepository.GetDutyAssignmentByStudentCode(code);
                var student = studentRepository.GetByCode(code);
                var dutyAssignments = dutyAssignmentRepository.GetDutyAssignments();

                if (student == null)
                {
                    Console.Write("Record not found");
                    return;
                }

                dutyAssignments.Remove(dutyAssignment);
                dutyAssignmentRepository.RefreshFile();
                Console.WriteLine($"{dutyAssignment.DutyName} duty successfully deleted for {dutyAssignment.StudentName}");
            }
            catch (Exception ex)
            {
                Console.Write($"Something went wrong:{ex.Message}");
            }
        }

        public void UpdateDutyToStudent(int id, DutyAssignmentDto request)
        {
            var dutyAssignment = dutyAssignmentRepository.GetById(id);
            var student = studentRepository.GetById(id);
            var duty = dutyRepository.GetById(id);

            if (duty == null || student == null)
            {
                Console.WriteLine("Record not found");
                return;
            }

            if (dutyAssignment != null)
            {
                Console.Write("Update id: ");
                request.DutyId = int.Parse(Console.ReadLine());

                Console.Write("Update student code: ");
                request.StudentCode = Console.ReadLine();

                Console.Write("Update duty name: ");
                request.DutyName = Console.ReadLine();

                Console.Write("Update student name: ");
                request.StudentName = Console.ReadLine().Trim();


                dutyAssignment.Id = request.DutyId;
                dutyAssignment.StudentName = request.StudentName;
                dutyAssignment.DutyName = request.DutyName;
                dutyAssignment.StudentCode = request.StudentCode;
                dutyAssignment.ModifiedAt = DateTime.UtcNow;

                dutyAssignmentRepository.RefreshFile();

                Console.WriteLine($"Duty assignment successfully updated!");
                return;
            }

            Console.WriteLine($"Duty assignment not found!");

        }

        public void ViewAllDutyToStudent()
        {
            var duties = dutyAssignmentRepository.GetDutyAssignments();
            var table = new ConsoleTable("Student Code", "Student Name", "Duty Name", "Created", "Modified");

            if (duties.Count != 0)
            {
                foreach (var duty in duties)
                {
                    table.AddRow(duty.StudentCode, duty.StudentName, duty.DutyName, duty.CreatedAt, duty.ModifiedAt);
                }

                table.Write(Format.Alternative);
                return;
            }

        }

        public void ViewDutyToAStudent(string dutyName)
        {
            var dutyAssignment = dutyAssignmentRepository.GetAllDutyAssignments(dutyName);
            var table = new ConsoleTable("Student Code", "Student Name", "Duty Name", "Created", "Modified");

            if (dutyAssignment != null)
            {
                foreach (var duty in dutyAssignment)
                {
                    table.AddRow(duty.StudentCode, duty.StudentName, duty.DutyName, duty.CreatedAt, duty.ModifiedAt);
                }

                table.Write(Format.Default);
                return;
            }

        }


    }


}
