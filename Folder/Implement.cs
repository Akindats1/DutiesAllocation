using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DutiesAllocationApp.Folder
{
    public static class Implement
    {
        public static void ImplementAll()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("====Kitchen duty====");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(Helper.KitchenAllocation());
            Console.WriteLine();


            Console.WriteLine("====Classroom Cleaning====");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(Helper.Classroom());
            Console.WriteLine();


            Console.WriteLine("====Corridor and staircase cleaning====");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(Helper.AllcorridorsAndStaircase());
            Console.WriteLine();


            Console.WriteLine("====Dinning Cleaning====");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(Helper.Dinning());
            Console.WriteLine();


            Console.WriteLine("====Toilet Cleaning====");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(Helper.Toilet());
            Console.WriteLine();


            Console.WriteLine("====Surroundings Cleaning====");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(Helper.Surroundings());
            Console.WriteLine();


            Console.WriteLine("====Sadr's Office Cleaning and Mosque Preparation====");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(Helper.SadrOfficeAndMosquePreparation());
            Console.WriteLine();

            
            Console.WriteLine("==== Supervision ====");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(Helper.Supervision());
            Console.WriteLine();
        }
    }
}