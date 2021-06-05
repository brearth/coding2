using System;

namespace ConsoleApp58
{
    class Program
    {           
        static void Main(string[] args)
        {

            
            double bmrmale ,bmrfemale;
            bool loop = false;
            Console.WriteLine("Basal Metabolic Rate");
            Console.WriteLine("");
            Console.WriteLine("*rules*");
            Console.WriteLine("1.Height Use Centimeter");
            Console.WriteLine("2.Weight Use Kilogram");
            Console.WriteLine("3.Gender Male = 1");
            Console.WriteLine("4.Gender Female = 2");        
            Console.WriteLine("");
            Console.Write("What Is Your Gender : ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Input Your Age : ");          
            int age = int.Parse(Console.ReadLine());
            Console.Write("Input Your weigt : ");
            float weight = float.Parse(Console.ReadLine());
            Console.Write("Input Your Height : ");
            float height = float.Parse(Console.ReadLine());
                  
            
            if (number == 1)
            {
                bmrmale = 66 + (13.7 * weight) + (5 * height) - (6.8 * age);
                Console.WriteLine("Your Basal Metabolic Rate Is : " + bmrmale);
            }
            else if (number == 2)
            {
                bmrfemale = 665 + (9.6 * weight) + (1.8 * height) - (4.7 * age); 
                Console.WriteLine("Your Basal Metabolic Rate Is : " + bmrfemale);
            }
            else
            {
                Console.WriteLine("Input Only 1 or 2");
            }

        }
    }
}
