using System;
using System.Collections.Generic;
using DutiesAllocationApp.Entities;

namespace DutiesAllocationApp.Shared
{
    public static class Helper
    {
        public static string GenerateCode(int id)
        {
            

            return $"MGQS-{id.ToString("0000")}";
        }

        public static string GenerateCode(char Dutyid)
        {

            return $"Duty-{Dutyid.ToString()}";

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