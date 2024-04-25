using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CowsAndBulls
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("--------------MENU--------------");
            Console.WriteLine("1. Play standard game(4 digits)");
            Console.WriteLine("2. Change number of digits");
            Console.WriteLine("3. Quit");
            string UserChoice = Console.ReadLine();
            int numOfDigits = 4;

            if (UserChoice == "3")
            {
                Environment.Exit(0);
            }
            if (UserChoice == "2")
            {
                Console.WriteLine("How many digits?");
                numOfDigits = Convert.ToInt32(Console.ReadLine());
            }
            int numOfGuesses = 0;
            Boolean TorF = false;
            Random rnd = new Random();
            int[] num = new int[numOfDigits];

            while (TorF != true)
            {
                for (int i = 0; i < num.Length; i++)
                {
                    num[i] = rnd.Next(1, 9);
                }
                if (num.Length == num.Distinct().Count())
                {
                    TorF = true;
                }
            }  



            bool CorrectOrFalse = false;
            while (CorrectOrFalse == false)
            {
                Console.WriteLine("-------------------------------------------------------------------------------------");
                Console.WriteLine("Enter a " + num.Length + " digit number with disinct digits that doesn't start with zero. ");
                string cheat = Console.ReadLine();
                if (cheat == "cheat")
                {
                    Console.Write("The number is ");
                    for (int i = 0; i < num.Length; i++)
                    {
                        Console.Write(num[i]);
                    }
                    Console.WriteLine("");
                }
                else
                {
                    int unum1 = Convert.ToInt32(cheat);
                    int[] unum = Array.ConvertAll(unum1.ToString().ToArray(), x => (int)x - 48);
                    TorF = false;
                    numOfGuesses++;


                    while (TorF != true)
                    {
                        if (unum.Length == unum.Distinct().Count() && unum.Length == num.Length)
                        {
                            TorF = true;
                        }
                        else
                        {
                            Console.WriteLine("-------------------------------------------------------------------------------------");
                            Console.WriteLine("Invalid! Enter a " + num.Length + " digit number with disinct digits that doesn't start with zero. ");
                            unum1 = Convert.ToInt32(Console.ReadLine());
                            unum = Array.ConvertAll(unum1.ToString().ToArray(), x => (int)x - 48);
                        }
                    }

                    int Cows = 0;
                    int Bulls = 0;
                    for (int i = 0; i < unum.Length; i++)
                    {
                        if (num[i] == unum[i])
                        {
                            Bulls++;
                        }
                        else if (Array.IndexOf(num, unum[i]) != -1) 
                        {
                            Cows++;
                        }
                    }



                    Console.WriteLine("Bulls:" + Bulls + "   Cows:" + Cows);
                    if (Bulls == num.Length)
                    {
                        CorrectOrFalse = true;
                        Console.WriteLine("Well Done you win!!!");

                    } 
                }
            }
            Console.WriteLine("It took you " + numOfGuesses + " guesses.");
            string blank = Console.ReadLine();
        }
    }
}
