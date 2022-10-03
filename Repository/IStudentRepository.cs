using System;
using DutiesAllocationApp.Entities;
using System.Collections.Generic;

namespace DutiesAllocationApp.Repository
{
    public interface IStudentRepository
    {
        Student GetByIdOrCode(int id, string code);
        Student GetById(int id);
        Student GetByCode(string code);
        List<Student> GetAll();
        void WriteToFile(Student student);
        void RefreshFile();
    }
}