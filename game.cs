using System;

namespace ConsoleApp57
{
    class Program
    {
        enum Difficulty
        {
            Easy,
            Normal,
            Hard
        }
        struct Problem
        {
            public string Message;
            public int Answer;

            public Problem(string message, int answer)
            {
                Message = message;
                Answer = answer;
            }
        }

        static Problem[] GenerateRandomProblems(int numProblem)
        {
            Problem[] randomProblems = new Problem[numProblem];

            Random rnd = new Random();
            int x, y;

            for (int i = 0; i < numProblem; i++)
            {
                x = rnd.Next(50);
                y = rnd.Next(50);
                if (rnd.NextDouble() >= 0.5)
                    randomProblems[i] =
                    new Problem(String.Format("{0} + {1} = ", x, y), x + y);
                else
                    randomProblems[i] =
                    new Problem(String.Format("{0} - {1} = ", x, y), x - y);
            }

            return randomProblems;
        }

        static void Main(string[] args)
        {
            Difficulty level = 0;
            double score = 0;          
            bool loop = false;
            
            while (loop == false)
            {
                Console.Write("TIMER:");
                Console.Write(DateTimeOffset.Now.ToUnixTimeSeconds());
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("[]--- Play Game---[]");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.Write("Start By Press 1 : ");           


                int number = int.Parse(Console.ReadLine());
                Console.WriteLine();
                if (number == 1)
                {
                    Console.WriteLine(" Menu");
                    Console.WriteLine("");
                    Console.WriteLine(" 0 : Start");
                    Console.WriteLine(" 1 : Setting");
                    Console.WriteLine(" 2 : Exit");
                    Console.WriteLine("");
                    Console.WriteLine("Difficulty is -{0}- Your score is |{1}| ",  level,score);
                    Console.WriteLine("");
                    Console.Write("Select :");
                }
                else
                {
                    Console.WriteLine("Please input 1");
                }

              static Difficulty option()
                {
                    Difficulty levels = Difficulty.Easy | Difficulty.Hard | Difficulty.Normal;
                    string level;
                    Console.WriteLine("Select Level");
                    Console.WriteLine("");
                    Console.WriteLine("Easy = 0");
                    Console.WriteLine("");
                    Console.WriteLine("Normal = 1");
                    Console.WriteLine("");
                    Console.WriteLine("Hard = 2");
                    Console.WriteLine("");
                    Console.Write("your difficulty is : ");
                    level = Console.ReadLine();

                    if (level == "0")
                    {
                        levels = Difficulty.Easy;
                    }
                    else if (level == "1")
                    {
                        levels = Difficulty.Normal;
                    }
                    else if (level == "2")
                    {
                        levels = Difficulty.Hard;
                    }
                    return levels;
                }


                char main = char.Parse(Console.ReadLine());
                switch (main)
                {
                    case '0':
                        score = game(level);
                        Console.WriteLine("Difficulty is -{0}- Your score is |{1}| ", level, score);
                        break;
                    case '1':
                        level = option();
                        Console.WriteLine("Difficulty is -{0}- Your score is |{1}| ", level, score);
                        break;
                    case '2':
                        loop = true;
                        long start = DateTimeOffset.Now.ToUnixTimeSeconds();
                        bool stop = false;
                        Console.WriteLine();
                        Console.WriteLine("This Game Ended");
                        Console.WriteLine();
                        Console.WriteLine("GGEZ");
                        break;
                    default:
                        Console.WriteLine("Plase input only 0-2 ");
                        break;

               }        
            }
        }





        static double game(Difficulty level)
        {
            int NumberofQuestion;
            NumberofQuestion = 0;
            Problem[] randomProblems = GenerateRandomProblems(0);

            if ((int)level == 0)
            {
                NumberofQuestion = 3;
            }
            else if ((int)level == 1)
            {
                NumberofQuestion = 5;
            }
            else if ((int)level == 2)
            {
                NumberofQuestion = 7;
            }
            
            randomProblems = GenerateRandomProblems(NumberofQuestion);

            double Timer, Finisher;
            int inputAnswer, CorrectAns;
            CorrectAns = 0;
            Timer = DateTimeOffset.Now.ToUnixTimeSeconds();
            int i = 0;

            while ( i < NumberofQuestion)
            {
                Console.Write(randomProblems[i].Message);
                inputAnswer = int.Parse(Console.ReadLine());
                if (inputAnswer == randomProblems[i].Answer)
                {
                    CorrectAns = CorrectAns + 1;
                }
                i++;
            }
            Finisher = DateTimeOffset.Now.ToUnixTimeSeconds();

            double Qc, Qa, DeltaT, d, T1, T2;
            Qc = CorrectAns;
            Qa = NumberofQuestion;
            T1 = Timer;
            T2 = Finisher;
            DeltaT = T2 - T1;
            d = (int)level;

            double s = (Qc / Qa) * (25 - Math.Pow(d, 2)) / Math.Max(DeltaT, 25 - (Math.Pow(d, 2)) * Math.Pow((2 * d) + 1, 2));

            return s;

        }   
    }
} 

