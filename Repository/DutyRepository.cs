using DutiesAllocation.Entities;

namespace DutiesAllocationApp.Repository
{
    public class DutyRepository : IDutyRepository
    {
        private static List<Duty> dutyList;
        

        public DutyRepository()
        {
            ReadFromFile();
        }

        private void ReadFromFile()
        {

            dutyList = new List<Duty>();
            try
            {
                if (File.Exists(Constants.fullPath2))
                {
                    var lines = File.ReadAllLines(Constants.fullPath2);
                    foreach (var line in lines)
                    {
                        var duty = Duty.ToDuty(line);
                        dutyList.Add(duty);
                        
                    }
                }
                else
                {
                    var dir = Constants.dir;
                    Directory.CreateDirectory(dir);
                    var fileName2 = Constants.fileName2;
                    var fullPath2 = Path.Combine(dir, fileName2);
                    using (File.Create(fullPath2))
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<Duty> GetAllDuty()
        {
            return dutyList;
        }

      

        public void RefreshFile()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(Constants.fullPath2))
                {
                    foreach (var duty in dutyList)
                    {
                        writer.WriteLine(duty.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void WriteToFile(Duty duty)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(Constants.fullPath2, true))
                {
                    writer.WriteLine(duty.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

       

        public Duty GetById(int id)
        {
            return dutyList.Find(i => i.Id == id);
        }
    }
}
