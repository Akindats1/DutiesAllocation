using DutiesAllocation.Entities.Dto;
using DutiesAllocationApp.Entities;

namespace DutiesAllocationApp.Services.Contracts
{
    public interface IDutyService
    {
        void Create(DutyDto request);
        void GetAll();
        void Update(int id, DutyDto request);
        void Delete(int id);
        void GetDuty(string dutyname);
    }
}
