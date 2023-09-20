using DutiesAllocationApp.Entities;

namespace DutiesAllocationApp.Repository.Contracts
{
    public interface IDutyRepository
    {
        Duty GetById(int id);
        Duty GetByName(string name);
        List<Duty> GetAll();
        void WriteToFile(Duty entity);
        void RefreshFile();
        List<string> StudentDuty();


    }
}