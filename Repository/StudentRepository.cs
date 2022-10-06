using DutiesAllocation.Repository;
using DutiesAllocationApp.Entities;
using DutiesAllocationApp.Repository.Contracts;

namespace DutiesAllocationApp.Repository
{
    public class StudentRepository : IStudentRepository
    {
        public static List<Student> students;
        public StudentRepository()
        {
            students = new List<Student>();
            ReadFromFile();
        }

        public Student GetByCode(string code)
        {
            return students.Find(i => i.Code == code);
        }

        public Student GetById(int id)
        {
            return students.Find(i => i.Id == id);
        }

        public Student GetByIdOrCode(int id, string code)
        {
            return students.Find(i => i.Id == id || i.Code == code);
        }

        public List<Student> GetAll()
        {
            return students;
        }

        public void RefreshFile()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(Constants.studentFilePath))
                {
                    foreach (var student in students)
                    {
                        writer.WriteLine(student.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void WriteToFile(Student entity)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(Constants.studentFilePath, true))
                {
                    writer.WriteLine(entity.ToString());
                }
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
                if (File.Exists(Constants.studentFilePath))
                {
                    var lines = File.ReadAllLines(Constants.studentFilePath);
                    foreach (var line in lines)
                    {
                        var student = Student.ToStudent(line);
                        students.Add(student);
                    }
                }
                else
                {
                    var dir = Constants.dir;
                    Directory.CreateDirectory(dir);
                    var fileName = Constants.studentFile;
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