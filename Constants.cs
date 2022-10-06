namespace DutiesAllocationApp
{
    public static class Constants
    {
        public const string dir =  "files";
        public const string studentFile = "students.txt";
        public static string studentFilePath = Path.Combine(dir, studentFile);
        public const string dutyNameFile = "dutylist.txt";
        public static string dutyFilePath = Path.Combine(dir, dutyNameFile);
    }
}