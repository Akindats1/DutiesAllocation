using DutiesAllocationApp.Entities;
using DutiesAllocationApp.Repository.Contracts;

namespace DutiesAllocationApp.Repository
{
    public class DutyAssignmentRepository : IDutyAssignmentRepository
    {
        private static List<DutyAssignment> dutyAssignments;
        public DutyAssignmentRepository()
        {
            dutyAssignments = new List<DutyAssignment>();
            ReadFromFile();
        }

        private void ReadFromFile()
        {
            try
            {
                if (File.Exists(Constants.dutyAssignmentFilePath))
                {
                    var lines = File.ReadAllLines(Constants.dutyAssignmentFilePath);
                    foreach (var line in lines)
                    {
                        var dutyAssigned = DutyAssignment.ToDutyAssignment(line);
                        dutyAssignments.Add(dutyAssigned);
                    }
                }
                else
                {
                    var dir = Constants.dir;
                    Directory.CreateDirectory(dir);
                    
                    
                    using (File.Create(Constants.dutyAssignmentFilePath))
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public IEnumerable<DutyAssignment> GetAllDutyAssignments(string dutyName)
        {
            return dutyAssignments.Where(a => a.DutyName == dutyName);
        }

        public List<DutyAssignment> GetDutyAssignments()
        {
            return dutyAssignments;
        }

        public void RefreshFile()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(Constants.dutyAssignmentFilePath))
                {
                    foreach (var dutyAssigned in dutyAssignments)
                    {
                        writer.WriteLine(dutyAssigned.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void WriteToFile(DutyAssignment entity)
        {
            try
            {
                using StreamWriter writer = new(Constants.dutyAssignmentFilePath, true);
                writer.WriteLine(entity.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public DutyAssignment GetById(int id)
        {
           
            return dutyAssignments.Find(i => i.Id == id);
            
        }

        public DutyAssignment GetDutyAssignmentByStudentCode(string code)
        {
            return dutyAssignments.Find(i => i.StudentCode == code);    
        }

        
    }
}
