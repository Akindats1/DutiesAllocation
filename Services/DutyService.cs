using DutiesAllocation.Entities.Dto;
using DutiesAllocation.Repository;
using DutiesAllocationApp.Entities;
using DutiesAllocationApp.Repository;
using DutiesAllocationApp.Repository.Contracts;
using DutiesAllocationApp.Services.Contracts;

namespace DutiesAllocationApp.Services
{
    public class DutyService : IDutyService
    {
        private static IDutyRepository dutyRepository;

        public DutyService()
        {
            dutyRepository = new DutyRepository();
        }

        public void Create(DutyDto request)
        {
            var duties = dutyRepository.GetAll();
            int id = (duties.Count != 0) ? duties[duties.Count - 1].Id + 1 : 1;

            Console.Write("Enter duty name: ");
            request.DutyName = Console.ReadLine().Trim();

            Console.Write("Enter duty description (optional): ");
            request.Description = Console.ReadLine();

            var duty = new Duty
            {
                Id = id,
                DutyName = request.DutyName,
                Description = request.Description,
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = new DateTime(0001, 01, 01)
            };

            var isDutyExist = dutyRepository.GetById(duty.Id);

            if (isDutyExist == null)
            {
                duties.Add(duty);
                dutyRepository.WriteToFile(duty);
                Console.WriteLine($"Duty created successfully!");
            }
            else
            {
                Console.WriteLine($"Duty with {duty.Id} already exist!");
            }
        }

        public void Delete(int id)
        {
            try
            {
                var duty = dutyRepository.GetById(id);
                var duties = dutyRepository.GetAll();

                if (duty == null)
                {
                    Console.WriteLine($"Duty not found!");
                }

                duties.Remove(duty);
                dutyRepository.RefreshFile();
                Console.WriteLine($"Duty with the id: {id} successfully deleted.");

            }
            catch (Exception ex)
            {
                Console.Write($"Something went wrong:{ex.Message}");
            }
        }

        public void GetAll()
        {
            var duties = dutyRepository.GetAll();

            foreach (var duty in duties)
            {
                PrintListView(duty);
            }
        }

        public void PrintListView(Duty duty)
        {
            var dateCreated = duty.CreatedAt.ToShortDateString();
            string dateModified = String.Empty;

            if (duty.ModifiedAt == new DateTime(0001, 01, 01))
            {
                dateModified += "Not modified yet";
            }
            else if (duty.CreatedAt.ToShortDateString() == duty.ModifiedAt.ToShortDateString())
            {
                dateModified += duty.ModifiedAt.ToString("hh:mm tt");
            }
            else
            {
                dateModified += duty.ModifiedAt.ToShortDateString();
            }

            Console.WriteLine($"Duty Name: {duty.DutyName}\tDescription: {duty.Description}\tCreated: {dateCreated}\tModified: {dateModified}");
        }

        public void Update(int id, DutyDto request)
        {
            var duty = dutyRepository.GetById(id);

            if (duty != null)
            {
                Console.Write("Update duty name: ");
                request.DutyName = Console.ReadLine();

                Console.Write("Update duty description: ");
                request.Description = Console.ReadLine();

                duty.DutyName = request.DutyName;
                duty.Description = request.Description;
                duty.ModifiedAt = DateTime.UtcNow;

                dutyRepository.RefreshFile();

                Console.WriteLine($"Duty successfully updated!");
            }
            else
            {
                Console.WriteLine($"Duty not found!");
            }
        }
    }
}
