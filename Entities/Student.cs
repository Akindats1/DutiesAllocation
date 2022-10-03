using System;
using System.Collections.Generic;
using DutiesAllocationApp.Enums;

namespace DutiesAllocationApp
{
    public class Student
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public Duty Duty{ get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public DateTime Date { get; set; }

        public override string ToString()
        {
            return $"{Id}\t{Code}\t{FirstName}\t{LastName}\t{Gender}\t{Duty}\t{Phone}\t{Password}\t{Date}";
        }

        public static Student ToStudent(string str)
        {
            var studentStr = str.Split("/t");

            var student = new Student
            {
                Id = int.Parse(studentStr[0]),
                Code = studentStr[1],
                FirstName = studentStr[2],
                LastName = studentStr[3],
                Gender = Enum.Parse<Gender>(studentStr[4]),
                Duty = Enum.Parse<Duty>(studentStr[5]),
                Phone = studentStr[6],
                Password = studentStr[7],
                Date = DateTime.Parse(studentStr[8])

            };
            return student;
        }
        
    

    }
}