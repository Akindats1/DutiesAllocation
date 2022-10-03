using System;
using DutiesAllocationApp.Enums;
using DutiesAllocationApp.Entities;

namespace DutiesAllocationApp.Entities
{
    public class UpdateStudentDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public Duty Duty { get; set; }
        public string Phone  { get; set; }
    }
}