using System;
using DutiesAllocationApp.Repository;

namespace DutiesAllocationApp
{
    public static class Constants
    {
        public const string dir =  @"C:\Users\user\Documents\DutiesAllocationApp\Record";
        public const string fileName = "student.txt";
        public const string fileName2 = "duty.txt";
        public static string fullPath = dir + "\\" + fileName;

        public static string fullPath2 = dir + "\\" + fileName2;

    }
}