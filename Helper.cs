using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DutiesAllocationApp
{
    public static class Helper
    {
        
        public static void KitchenAllocation()
        {
            List<string> kitchen = new List<string>();

            kitchen.Add("Lukman AbdulMalik");
            kitchen.Add("Haruna AbdulMalik");
            kitchen.Add("Adelakun Abdullateef");
            kitchen.Add("Haruna Habeebullah");
            kitchen.Add("Mahmud Ahmad AbdulWaheed");

            int i = 0;
            
            foreach (var item in kitchen)
            {
                Console.WriteLine($"{++i}.{item}");
            }
        }


        public static void Classroom()
        {
            List<string> classroom = new List<string>();

            classroom.Add("Oni Bashir Muhammad Bashir");
            classroom.Add("Ismail Abdulwarith");

             int i = 1;
            
            foreach (var item in classroom)
            {
                Console.WriteLine($"{i++}.{item}");
            }


        }


        public static void AllcorridorsAndStaircase()
        {
            List<string> corridor = new List<string>();

            corridor.Add("Adeniran Munzir");
            corridor.Add("Elias Bashirudeen");

            int i = 0;
            
            foreach (var item in corridor)
            {
                Console.WriteLine($"{++i}.{item}");
            }
        }


        public static void Dinning()
        {
            List<string> dinning = new List<string>();

            dinning.Add("Akintola AbdulHaseeb");
            dinning.Add("Intisor AbdulAwwal");

            int i = 1;
            
            foreach (var item in dinning)
            {
                Console.WriteLine($"{i++}.{item}");
            }
        }


        public static void Toilet()
        {
            List<string> toilet = new List<string>();

            toilet.Add("Oluwa Muhammad");
            toilet.Add("AbdurRaheem AbdulBarr");

            int i = 0;
            
            foreach (var item in toilet)
            {
                Console.WriteLine($"{++i}.{item}");
            }
        }



        
        public static void Surroundings()
        {
            List<string> surrounding = new List<string>();

            surrounding.Add("Lawal AbdulRahman");
            surrounding.Add("Alabi Abdulsamad");

            int i = 0;
            
            foreach (var item in surrounding)
            {
                Console.WriteLine($"{++i}.{item}");
            }
        }



        public static string SadrOfficeAndMosquePreparation()
        {
            int i = 0;
            string worker = $"{++i}.Sultan AbdulSalam";

            return worker;
        }

        
        
       
    }
}