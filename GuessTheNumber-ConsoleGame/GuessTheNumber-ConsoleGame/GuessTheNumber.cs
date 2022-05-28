using System;

namespace GuessTheNumber_ConsoleGame
{
    class GuessTheNumber
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int num = rnd.Next(0, 100);

            int counter = 0;
            int guess = 0;

            Console.WriteLine("Guess the number between 0 and 100");            

            while (guess != num)
            {
                Console.Write("You guess: ");
                guess = int.Parse(Console.ReadLine());

                if (guess < num)
                {
                    Console.WriteLine("No, The number is bigger.");
                }
                else if (guess > num)
                {
                    Console.WriteLine("No, The number is smaller.");
                }

                counter++;
            }
            
            Console.WriteLine("You guess it!");            
            Console.WriteLine($"The number is: {num}, and you guess it from {counter} time.");

            Console.ReadLine();
        }
    }
}
