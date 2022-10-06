using DutiesAllocation.Entities;
using DutiesAllocationApp.Repository;
using DutiesAllocation.Entities.Dto;
using DutiesAllocationApp.Entities.Dto;


namespace DutiesAllocationApp.Services
{
    public class DutyService : IDutyService
    {
        private static IDutyRepository dutyRepository;

        public DutyService()
        {
            dutyRepository = new DutyRepository();
        }

        public void CreateNewDuty(DutyDto addDuty)
        {
            var dutyList = dutyRepository.GetAllDuty();

            int id = dutyList.Count == 0 ? 1 : dutyList[dutyList.Count - 1].Id + 1 ;
            

            Console.Write("Enter a new duty to add: ");
            addDuty.DutyName = Console.ReadLine();
            
            var dutyName = new Duty()
            {
                Id = id,
                DutyName = addDuty.DutyName,
                CreatedAt = DateTime.UtcNow
            };

            var findDuty = dutyRepository.GetById(dutyName.Id);
            if (findDuty != null)
            {
                
                Console.WriteLine($"Duty with id \"{dutyName.Id}\" already exists");
            }
            else
            {
                dutyList.Add(dutyName);
                dutyRepository.WriteToFile(dutyName);
                Console.WriteLine($"New duty with id \"{dutyName.Id}\" as been created successfully!");
            }
        }

       

        public void DeleteDuty(int id)
        {
            var duty = dutyRepository.GetById(id);
            var duties = dutyRepository.GetAllDuty();

            if(duty == null)
            {
                Console.WriteLine($"Duty with id \"{id}\" not found!");
            }
            else
            {
                duties.Remove(duty);
                dutyRepository.RefreshFile();
                Console.WriteLine($"Duty with the id: {id} successfully deleted!");
            }
        }

        public void GetAllDuty()
        {
            throw new NotImplementedException();
        }

        public void PrintDetailView(Duty duty)
        {
            Console.WriteLine($"Id: {duty.Id}\nDuty name: {duty.DutyName}\tDate: {duty.CreatedAt}");
            
        }

   

        public void UpdateDuty(int id, UpdateDutyDto updateDutyDto)
        {
            
            var duty = dutyRepository.GetById(id);

            Console.Write("Enter duty name to update: ");
            updateDutyDto.DutyName = Console.ReadLine();

            if(duty != null)
            {
                duty.DutyName = updateDutyDto.DutyName;
                dutyRepository.RefreshFile();

                Console.WriteLine($"Duty record with id \"{duty.Id}\" is successfully updated!");
            }
            else
            {
                Console.WriteLine($"Duty not found!");
            }

        }
        public void ViewAllDuty()
        {
            var duties = dutyRepository.GetAllDuty();

            foreach (var duty in duties)
            {
                PrintDetailView(duty);
            }
        }
    }
}
