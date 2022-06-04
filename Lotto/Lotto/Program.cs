using System;
using System.Collections.Generic;

namespace Lotto
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lotto");
            Console.WriteLine();
            Console.WriteLine("You need to guess at least 3 numbers from total 5 to get some reward.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);

            double jackpot = 1000;
            double playerBalance = 0;
            Random rnd = new Random();            
            
            StartGame:
            int[] playerNumbers = new int[5];

            for (int i = 0; i < playerNumbers.Length; i++)
            {
            Input:
                Console.Clear();
                Console.WriteLine($"The jackpot is: $ {jackpot:f2}, your balance is: $ {playerBalance:f2}");
                Console.WriteLine();
                Console.WriteLine("Please enter your numbers. They must be between 1 to 35");
                Console.WriteLine();
                Console.WriteLine($"Your numbers : {playerNumbers[0]}, {playerNumbers[1]}, {playerNumbers[2]}," +
                    $" {playerNumbers[3]}, {playerNumbers[4]}");
                Console.Write($"{i + 1} number: ");
                int input = int.Parse(Console.ReadLine());

                if (input < 1 || input > 35)
                {
                    Console.WriteLine("Invalid number try again, number must be from 1 to 35.");
                    Console.WriteLine("Press [enter] to continue");
                    Console.ReadLine();
                    goto Input;
                }

                playerNumbers[i] = input;
            }

            int[] lottoNumbers = new int[5];

            for (int i = 0; i < lottoNumbers.Length; i++)
            {
                NewNumber:

                int number = rnd.Next(1, 36);

                if (number != lottoNumbers[0] && number != lottoNumbers[1] && 
                    number != lottoNumbers[2] && number != lottoNumbers[3] && number != lottoNumbers[4])
                {
                    lottoNumbers[i] = number;
                }
                else
                {
                    goto NewNumber;
                }
                
            }

            Console.Clear();
            Console.WriteLine($"Your numbers are: {playerNumbers[0]}, {playerNumbers[1]}, {playerNumbers[2]}," +
                    $" {playerNumbers[3]}, {playerNumbers[4]}");
            Console.WriteLine($"Lotto numbers are: {lottoNumbers[0]}, {lottoNumbers[1]}, {lottoNumbers[2]}," +
                $" {lottoNumbers[3]}, {lottoNumbers[4]}");            

            int countGuessed = 0;
            Stack<int> numbers = new Stack<int>();

            for (int player = 0; player < playerNumbers.Length; player++)
            {
                for (int lotto = 0; lotto < lottoNumbers.Length; lotto++)
                {
                    if (playerNumbers[player] == lottoNumbers[lotto])
                    {
                        countGuessed++;
                        numbers.Push(playerNumbers[player]);
                    }
                }
            }

            Console.WriteLine($"Count guessed numbers: {numbers.Count}");

            if (numbers.Count != 0)
            {
                Console.Write("Your guessed numbers: |");

                while (numbers.Count > 0)
                {
                    Console.Write($"{numbers.Pop()}|");
                }
            }           

            Console.WriteLine();

            double reward = 0;

            if (countGuessed == 3)
            {
                reward = jackpot / 3;
                jackpot -= reward;
                Console.WriteLine($"Your reward is: $ {reward:F2}");
            }
            else if (countGuessed == 4)
            {
                reward = jackpot / 2;
                jackpot -= reward;
                Console.WriteLine($"Your reward is: $ {reward:F2}");
            }
            else if (countGuessed == 5)
            {
                reward = jackpot;
                jackpot -= reward;
                Console.WriteLine($"Your reward is: $ {reward:F2}");
            }
            else
            {
                Console.WriteLine("No reward!");
            }

            jackpot += 1000;
            playerBalance += reward;

            Console.WriteLine();
            Console.Write("Enter [C] to continue with new combination or [E] to Exit: ");
            char choice = char.Parse(Console.ReadLine().ToLower());

            switch (choice)
            {
                case 'c': goto StartGame;
                case 'e': return;
                default: return;                    
            }
        }
    }
}
