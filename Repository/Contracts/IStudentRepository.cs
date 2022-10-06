using DutiesAllocationApp.Entities;

namespace DutiesAllocationApp.Repository.Contracts
{
    public interface IStudentRepository
    {
        public Student GetByCode(string code);
        public Student GetByIdOrCode(int id, string code);
        Student GetById(int id);
        List<Student> GetAll();
        void WriteToFile(Student entity);
        void RefreshFile();
    }
}