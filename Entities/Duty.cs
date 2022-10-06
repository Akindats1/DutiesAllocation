using DutiesAllocationApp.Entities;

namespace DutiesAllocation.Entities;

public class Duty : BaseEntity
{
   
    public string DutyName { get; set; }
    

    public override string ToString()
    {
        return $"{Id}\t{DutyName}\t{CreatedAt}\t{ModifiedAt}";
    }

    public static Duty ToDuty(string str)
    {
        var dutyStr = str.Split("\t");

        var duty = new Duty
        {
            Id = int.Parse(dutyStr[0]), 
            DutyName = dutyStr[1],
            CreatedAt = DateTime.Parse(dutyStr[2]),
            ModifiedAt = DateTime.Parse(dutyStr[3])
        };

        return duty;
    }
}   

