using DutiesAllocation.Entities.Dto;
using DutiesAllocationApp.Entities;


namespace DutiesAllocationApp.Services
{
    public interface IStudentService
    {
        void Create(StudentDto request);
        void GetAll();
        void GetAStudent(int id);
        void Update(int id, UpdateStudentDto updateStudentDto);
        void Delete(int id);
        void PrintListView(Student student);
        void PrintDetailView(Student student);
        void AssignDutyToStudent(int id);
    }
}