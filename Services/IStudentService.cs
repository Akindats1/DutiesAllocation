using System;
using DutiesAllocationApp.Entities;


namespace DutiesAllocationApp.Services
{
    public interface IStudentService
    {
        Student Login(string code, string password);
        void Create(StudentDto request);
        void GetAll();
        void GetAStudent(int id);
        void Update(int id, UpdateStudentDto updateStudentDto);
        void Update(string code, UpdateStudentDto updateStudentDto);
        void Delete(int id);
        void PrintListView(Student student);
        void PrintDetailView(Student student);
        void ChangePassword(string code, string oldPassword, string newPassword, string confirmPassword);
        void AddAdminRecord();
    }
}