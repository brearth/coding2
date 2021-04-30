
using System;

namespace ConsoleApp46
{
    class Program
    {
        static void Pascal(int Row)
        {
            int Input = 1;

            for (int i = 0; i <= Row; i++)
            {
                for (int j = 0; j <= i; j++)
                {

                    if (j == 0 || i == 0)
                        Input = 1;
                    else
                        Input = Input * (i - j + 1) / j;
                    Console.Write(Input + " ");
                }
                Console.WriteLine();         
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Input the number for create level of pascal : ");
            Console.WriteLine();
            int Row = int.Parse(Console.ReadLine());
            Console.WriteLine();
            if (Row >= 0)
            {
                Pascal(Row);
            }
            else if(Row < 0)
            {
                Console.WriteLine("Invalid Pascal’s triangle row number.");
                Console.Write("Input the number for create level of pascal : ");
                Row = int.Parse(Console.ReadLine());
                Pascal(Row);
            }

        }
    
    }
}

