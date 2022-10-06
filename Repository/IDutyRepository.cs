using DutiesAllocation.Entities;
using DutiesAllocationApp.Entities;

namespace DutiesAllocationApp.Repository
{
    public interface IDutyRepository
    {
        Duty GetById(int id);
        List<Duty> GetAllDuty();
        void WriteToFile(Duty duty);
        void RefreshFile();
        
    }
}
