namespace DutiesAllocationApp.Shared
{
    public static class Helper
    {
        public static string GenerateCode(int id)
        {
            Random rnd = new Random();

            return $"MGQS-{id.ToString("0000")}";
        }


        public static int SelectEnum(string screenMessage, int validStart, int validEnd)
        {
            int outValue;
            do
            {
                Console.Write(screenMessage);
            } while (!(int.TryParse(Console.ReadLine() , out outValue) && isValid(outValue, validStart, validEnd)));
            return outValue;
        }

        public static bool isValid(int outValue, int start, int end)
        {
            return outValue >= start && outValue <= end;
        }
    }
}