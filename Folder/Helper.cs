using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DutiesAllocationApp
{
    public static class Helper
    {
        
        public static string KitchenAllocation()
        {
            List<string> kitchen = new List<string>();

            kitchen.Add("Lukman AbdulMalik");
            kitchen.Add("Ismail Abdulwarith");
            kitchen.Add("Intisor AbdulAwwal");
            kitchen.Add("Haruna Habeebullah");
            kitchen.Add("Elias Bashirudeen");
            kitchen.Add("Adeoye Aaishah");
            kitchen.Add("Bello Fateemah");
            kitchen.Add("Timehin Hameedah");
            
            int i = 0;
            string result = "";
            
            foreach (var item in kitchen)
            {
                result += $"{++i}.{item}\n";
            }
            return result;
        }


        public static string Classroom()
        {
            List<string> classroom = new List<string>();

            classroom.Add("Oni Bashir Muhammad Bashir");
            classroom.Add("Haruna AbdulMalik");

            int i = 1;
            string result = "";
            
            
            foreach (var item in classroom)
            {
                result += $"{i++}.{item}\n";
            }

            return result;


        }


        public static string AllcorridorsAndStaircase()
        {
            List<string> corridor = new List<string>();

            corridor.Add("Adeniran Munzir");
            corridor.Add("Mahmud Ahmad AbdulWaheed");

            int i = 0;
            string result = "";
            
            foreach (var item in corridor)
            {
                result += $"{++i}.{item}\n";
            }
            return result;
        }


        public static string Dinning()
        {
            List<string> dinning = new List<string>();

            dinning.Add("Akintola AbdulHaseeb");
            dinning.Add("Adelakun Abdullateef");
            dinning.Add("Jubreel Faranas");
            dinning.Add("Hamzah Fawazah");
            dinning.Add("Oyekola Hafsah-Qaanitah");
            dinning.Add("Lukman Zainab");
            

            int i = 1;
            string result = "";
            
            
            foreach (var item in dinning)
            {
                result += $"{i++}.{item}\n";
            }
            return result;
        }


        public static string Toilet()
        {
            List<string> toilet = new List<string>();

            toilet.Add("Alabi Abdulsamad");
            toilet.Add("Lawal AbdulRahman");

            int i = 0;
            string result = "";
            
            
            foreach (var item in toilet)
            {
                result += $"{++i}.{item}\n";
            }
            return result;
        }



        
        public static string Surroundings()
        {
            List<string> surrounding = new List<string>();

            
            surrounding.Add("Oluwa Muhammad");
            surrounding.Add("AbdurRaheem AbdulBarr");

            int i = 0;
            string result = "";
            
            foreach (var item in surrounding)
            {
                result +=  $"{++i}.{item}\n";
            }

            return result;    
        }



        public static string SadrOfficeAndMosquePreparation()
        {
            int i = 0;
            string worker = $"{++i}.Sultan AbdulSalam";

            return worker;
        }


        public static string Supervision()
        {
            List<string> supervisor = new List<string>();

            supervisor.Add("Bello AbdulRasheed");
            supervisor.Add("Bamgbose Balikiss");

            
            int i = 1;
            string result = "";
            
            foreach (var item in supervisor)
            {
                result += $"{i++}.{item}\n";
            }
            return result;
         }

        
        
       
    }
}