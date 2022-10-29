using DutiesAllocationApp.Entities;

namespace DutiesAllocationApp.Repository.Contracts
{
    public interface IDutyAssignmentRepository
    {
        DutyAssignment GetById(int id); 
        List<DutyAssignment> GetDutyAssignments();
        DutyAssignment GetDutyAssignmentByStudentCode(string code);
        IEnumerable<DutyAssignment> GetAllDutyAssignments(string dutyName);
        void WriteToFile(DutyAssignment entity);
        void RefreshFile();

    }
}
