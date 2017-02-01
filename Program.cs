using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace My_Capitals
{
    class Program
    {
        static void Main(string[] args)
        {
            byte attempts = 3; //quantity of attempts
            byte sum = 0; //correct answers counter            

            for (int j = 0; j < 4; j++)
            {
                string[] lines = File.ReadAllLines("capitals.txt");
                Random rand = new Random();
                int n = Convert.ToInt32(rand.Next(0, lines.Length + 1));
                string[] Country_Capital;
                string[] stringSeparators = new string[] { "; " };
                Country_Capital = lines[n].Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < 4; i++)
                {
                    Console.WriteLine("The country is {0}. What is the name of its capital?", Country_Capital[0]);
                    string variant = Console.ReadLine();
                    if (variant == Country_Capital[1])
                    {
                        sum++;
                        if (4 - sum != 0)
                        {
                            Console.WriteLine("You are right! You should guess {0} capitals more", 4 - sum);
                        }
                        attempts = 3;
                        if (4 - sum == 0)
                        {
                            Console.WriteLine("Congratulations! You have won!");
                            break;
                        }
                        break;
                    }
                    else
                    {
                        attempts--;
                        if (attempts != 0)
                        {
                            Console.WriteLine("Not right, you have {0} attempts left", attempts);
                        }
                        if (attempts == 0)
                        {
                            Console.WriteLine("You have lost. Start since the beginning\n");
                            attempts = 3;
                            sum = 0;
                            break;
                        }                        
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
