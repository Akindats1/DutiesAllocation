using ConsoleTables;

namespace DutiesAllocationApp.Entities
{
    public class Duty : BaseEntity
    {
        public string DutyName { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            var table = new ConsoleTable("Id", "DutyName", "Description");
            return $"{Id}\t{DutyName}\t{Description}\t{CreatedAt}\t{ModifiedAt}";
        }

        public static Duty ToDuty(string str)
        {
            var type = str.Split("\t");

            var duty = new Duty
            {
                Id = int.Parse(type[0]),
                DutyName = type[1],
                Description = type[2],
                CreatedAt = DateTime.Parse(type[3]),
                ModifiedAt = DateTime.Parse(type[4]),
            };
            return duty;
        }
    }
}