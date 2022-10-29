



namespace DutiesAllocationApp.Entities
{
    public class DutyAssignment : BaseEntity
    {
        public string StudentCode { get; set; } 
        public string StudentName { get; set; }
        public string DutyName { get; set;}
        

        public override string ToString()

        {
            return $"{Id}\t{StudentCode}\t{StudentName}\t{DutyName}\t{CreatedAt}\t{ModifiedAt}";
        }

        public static DutyAssignment ToDutyAssignment(string str)
        {
            var dutyAssigmentStr = str.Split("\t");

            var dutyassign = new DutyAssignment
            {
                Id = int.Parse(dutyAssigmentStr[0]),
                StudentCode = dutyAssigmentStr[1],
                StudentName = dutyAssigmentStr[2],
                DutyName = dutyAssigmentStr[3],
                CreatedAt = DateTime.Parse(dutyAssigmentStr[4]),    
                ModifiedAt = DateTime.Parse(dutyAssigmentStr[5])
            };

            return dutyassign;
        }
    }
}
