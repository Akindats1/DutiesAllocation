using DutiesAllocationApp.Entities;

namespace DutiesAllocationApp.Repository.Contracts
{
    public interface IDutyRepository
    {
        Duty GetById(int id);
        List<Duty> GetAll();
        void WriteToFile(Duty entity);
        void RefreshFile();
    }
}