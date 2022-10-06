using DutiesAllocation.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DutiesAllocation.Entities.Dto;
using DutiesAllocationApp.Entities.Dto;

namespace DutiesAllocationApp.Services
{
    public interface IDutyService
    {
        
        void UpdateDuty(int id, UpdateDutyDto updateDutyDto);
        void ViewAllDuty();
        void DeleteDuty(int id);
        void CreateNewDuty(DutyDto addDuty);
        void PrintDetailView(Duty duty);
        void GetAllDuty();
    }
}
