using System;
using System.IO;
using System.Collections.Generic;
using DutiesAllocationApp.Enums;
using DutiesAllocationApp.Entities;
using DutiesAllocationApp.Shared;



namespace DutiesAllocationApp.Repository
{
    public class StudentRepository : IStudentRepository
    {
        public static List<Student> students;
        public StudentRepository()
        {
            ReadFromFile();
        }

        private void ReadFromFile()
        {
            students = new List<Student>();
            try
            {
                if(File.Exists(Constants.fullPath))
                {
                    var lines = File.ReadAllLines(Constants.fullPath);
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
                    var fileName = Constants.fileName;
                    var fullPath = Path.Combine(dir, fileName);
                    using (File.Create(fullPath));
                }
               
            }
            catch(Exception ex)
            {
                Console.WriteLine("Aw snap:", ex.Message);
            }
        }

 
        public List<Student> GetAll()
        {
            return students;
        }

        public Student GetByCode(string code)
        {
            return students.Find(i => i.Code == code);
        }

        public Student GetById(int id)
        {
            return students.Find(i => i.Id == id);
        }

        public Student GetByIdOrCode(int id,string code)
        {
            return students.Find(i => i.Id == id || i.Code == code);
        }

        public void WriteToFile(Student student)
        {
            try
            {
                using(StreamWriter writer = new StreamWriter(Constants.fullPath, true))
                {
                    writer.WriteLine(student.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void RefreshFile()
        {
            try
            {
                using(StreamWriter writer = new StreamWriter(Constants.fullPath))
                {
                    foreach(var student in students)
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




    }
}