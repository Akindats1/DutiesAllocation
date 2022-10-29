using DutiesAllocationApp;
using DutiesAllocationApp.Entities;
using DutiesAllocationApp.Repository.Contracts;

namespace DutiesAllocation.Repository
{
    public class DutyRepository : IDutyRepository
    {
        public static List<Duty> duties;
        public static List<string> dutyNames;
        public DutyRepository()
        {
            duties = new List<Duty>();
            dutyNames = new List<string>();
            ReadFromFile();
        }

        public List<Duty> GetAll()
        {
            return duties;
        }

        public Duty GetById(int id)
        {
            return duties.Find(i => i.Id == id);
        }

        public void RefreshFile()
        {
            try
            {
                using StreamWriter writer = new(Constants.dutyFilePath);
                foreach (var duty in duties)
                {
                    writer.WriteLine(duty.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<string> StudentDuty()
        {
            return dutyNames;
        }

        public void WriteToFile(Duty entity)
        {
            try
            {
                using StreamWriter writer = new(Constants.dutyFilePath, true);
                writer.WriteLine(entity.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ReadFromFile()
        {
            try
            {
                if (File.Exists(Constants.dutyFilePath))
                {
                    var lines = File.ReadAllLines(Constants.dutyFilePath);
                    foreach (var line in lines)
                    {
                        var duty = Duty.ToDuty(line);
                        duties.Add(duty);
                    }
                }
                else
                {
                    var dir = Constants.dir;
                    Directory.CreateDirectory(dir);
                    var fileName = Constants.dutyNameFile;
                    var fullPath = Path.Combine(dir, fileName);
                    using (File.Create(fullPath))
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}