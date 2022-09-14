using System;
using DutiesAllocationApp;



Console.ForegroundColor = ConsoleColor.DarkRed;
Console.WriteLine("====Kitchen duty====");
Console.ForegroundColor = ConsoleColor.DarkBlue;
Helper.KitchenAllocation();
Console.WriteLine();


Console.WriteLine("====Classroom Cleaning====");
Console.ForegroundColor = ConsoleColor.DarkRed;
Helper.Classroom();
Console.WriteLine();


Console.WriteLine("====Corridor and staircase cleaning====");
Console.ForegroundColor = ConsoleColor.DarkCyan;
Helper.AllcorridorsAndStaircase();
Console.WriteLine();


Console.WriteLine("====Dinning Cleaning====");
Console.ForegroundColor = ConsoleColor.DarkGray;
Helper.Dinning();
Console.WriteLine();


Console.WriteLine("====Toilet Cleaning====");
Console.ForegroundColor = ConsoleColor.DarkRed;
Helper.Toilet();
Console.WriteLine();


Console.WriteLine("====Surroundings Cleaning====");
Console.ForegroundColor = ConsoleColor.DarkBlue;
Helper.Surroundings();
Console.WriteLine();


Console.WriteLine("====Sadr's Office Cleaning and Mosque Preparation====");
Console.ForegroundColor = ConsoleColor.DarkRed;
Console.WriteLine(Helper.SadrOfficeAndMosquePreparation());
Console.WriteLine();

 
Console.WriteLine("==== Supervision ====");
Console.ForegroundColor = ConsoleColor.DarkCyan;
Helper.Supervision();
Console.WriteLine();


