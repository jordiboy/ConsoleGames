using System;
using System.Threading;

namespace GuessTheNumber
{
    class Program
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
            Console.WriteLine();
            Thread.Sleep(3000);
            Console.Write("Now, let's change the role, write me a number and I'll gess it:");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine($"Ha, ha, humas! Your number is: {number}");
            Console.WriteLine("When you write a number, I'll always know it.");
            Thread.Sleep(7000);
            Console.WriteLine(); 
            Console.WriteLine("Now, seriosly, think about a number and keep it in your mind");
            Console.WriteLine("Just write me, if is 'bigger' or 'smaller' from my guess.");
            Console.WriteLine("And if I guess it, write 'right'.");
            Console.WriteLine();
            Thread.Sleep(10000);
            Console.Write("Press [Enter], when you ready with the number.");
            Console.ReadLine();
            Console.WriteLine();
                        
            counter = 0;
            int lower = 0;
            int higher = 100;
            num = rnd.Next(lower, higher);

            Console.WriteLine($"Your number is: {num}");
            string command = Console.ReadLine().ToLower();

            while (command != "right")
            {
                if (command == "smaller")
                {
                    higher = num - 1;
                }
                else if (command == "bigger")
                {
                    lower = num + 1;
                }
                num = rnd.Next(lower, higher);

                Console.WriteLine($"Your number is: {num}");
                command = Console.ReadLine().ToLower();

                counter++;
            }
            Console.WriteLine();
            Console.WriteLine($"I guess your number from {counter} time.");

            Console.ReadLine();
        }
    }
}
