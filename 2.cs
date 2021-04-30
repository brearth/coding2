using System;

namespace ConsoleApp47
{
    class Program
    {
        static string ReplicateSeqeunce(string halfDNASequence)
        {
            string result = "";
            foreach (char nucleotide in halfDNASequence)
            {
                result += "TAGC"["ATCG".IndexOf(nucleotide)];
            }
            return result;
        }
        static bool IsValidSequence(string halfDNASequence)
        {
            foreach (char nucleotide in halfDNASequence)
            {
                if (!"ATCG".Contains(nucleotide))
                {
                    return false;
                }
            }
            return true;
        }
        static void Main(string[] args)
        {
            while (true)
            {
                bool pause = false;             
                Console.Write("Input the DNA sequence: ");
                string DNA = Console.ReadLine();
                if (IsValidSequence(DNA) == true)
                {
                    Console.WriteLine("Current half DNA sequcence: {0}", DNA);
                    while (true)
                    {
                        Console.Write("Do you want to replicate it ? (Y / N) :  ");
                        string YN = Console.ReadLine();
                        if (YN == "Y")
                        {
                            Console.WriteLine("Current half DNA sequence :{0}", ReplicateSeqeunce(DNA));
                            break;
                        }
                        else if (YN == "N")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please input Y or N");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("The half DNA is invalid");
                }
                Console.Write("Do you want to process another sequence ? (Y/N) : ");

                do
                {
                    string Ans = Console.ReadLine();
                    if (Ans == "Y")
                    {
                        break;
                    }
                    else if (Ans == "N")
                    {
                        pause = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please input Y or N.");

                    }
                }while (true);

                    if (pause == true)
                {
                    break;
                }
            } while (true) ;
        }
    }
}
