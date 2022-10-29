using DutiesAllocationApp.Entities;
using DutiesAllocationApp.Entities.Dto;

namespace DutiesAllocationApp.Services.Contracts
{
    public interface IDutyAssignmentService
    {
        void AssignDutyTostudent(DutyAssignmentDto request);
        void ViewAllDutyToStudent();
        void DeleteDutyToStudent(string code);
        void ViewDutyToAStudent(string dutyName);
        void UpdateDutyToStudent(int dutyId,  DutyAssignmentDto studentCode);
        void PrintView(DutyAssignment dutyAssignment);

    }
}
