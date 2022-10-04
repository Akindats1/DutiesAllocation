using DutiesAllocationApp.Enums;

namespace DutiesAllocation.Entities.Dto
{
    public class UpdateStudentDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Phone  { get; set; }
    }
}