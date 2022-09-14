using System;
using DutiesAllocationApp;



Console.ForegroundColor = ConsoleColor.DarkGray;
Console.WriteLine("====Kitchen duty====");
Helper.KitchenAllocation();
Console.WriteLine();

Console.ForegroundColor = ConsoleColor.DarkYellow;
Console.WriteLine("====Classroom Cleaning====");
Helper.Classroom();
Console.WriteLine();

Console.ForegroundColor = ConsoleColor.DarkGreen;
Console.WriteLine("====Corridor and staircase cleaning====");
Helper.AllcorridorsAndStaircase();
Console.WriteLine();

Console.ForegroundColor = ConsoleColor.DarkRed;
Console.WriteLine("====Dinning Cleaning====");
Helper.Dinning();
Console.WriteLine();

Console.ForegroundColor = ConsoleColor.DarkCyan;
Console.WriteLine("====Toilet Cleaning====");
Helper.Toilet();
Console.WriteLine();

Console.ForegroundColor = ConsoleColor.DarkRed;
Console.WriteLine("====Surroundings Cleaning====");
Helper.Surroundings();
Console.WriteLine();

Console.ForegroundColor = ConsoleColor.DarkGreen;
Console.WriteLine("====Sadr's Office Cleaning and Mosque Preparation====");
Console.WriteLine(Helper.SadrOfficeAndMosquePreparation());
Console.WriteLine();


