using System;

namespace DiceGame
{
    class DiceGame
    {
        static void Main(string[] args)
        {
            int[] result = new int[2];                  // i0 = playerWins, i1 = computerWins
            Random rnd = new Random();

        StartGame:

            Console.Clear();
            Console.WriteLine("Dice Game");
            Console.WriteLine();
            Console.WriteLine("You have 10 rounds, to win the game.");
            Console.Write("Press [Enter] to continue...");
            Console.ReadLine();

            for (int round = 1; round <= 10; round++)
            {
                int computer = rnd.Next(1, 7);

                Console.WriteLine($"Round {round}");
                Console.WriteLine();
                Console.WriteLine($"Computer rolled: {computer}");
                Console.Write("Press [Enter] to roll the dice...");
                Console.ReadLine();

                int player = rnd.Next(1, 7);

                Console.WriteLine($"You rolled: {player}");                

                if (computer > player)
                {
                    Console.WriteLine("Computer won this round.");
                    result[1]++;
                }
                else if (player > computer)
                {
                    Console.WriteLine("You won this round.");
                    result[0]++;
                }
                else
                {
                    Console.WriteLine("This round is a draw.");
                }

                Console.WriteLine();
                Console.WriteLine($"Current score is: You {result[0]} wins - Computer {result[1]} wins.");
                Console.WriteLine("Press [Enter] to continue...");
                Console.ReadLine();
            }

            Console.WriteLine("Game over.");
            Console.WriteLine($"The final score is: You {result[0]} wins - Computer {result[1]} wins.");

            if (result[0] > result[1])
            {
                Console.WriteLine("You won!");
            }
            else if (result[1] > result[0])
            {
                Console.WriteLine("Computer won.");
            }
            else
            {
                Console.WriteLine("The game is draw.");
            }

            Console.WriteLine();
            Console.Write("For new game enter [N]ew or [E]xit to exit: ");
            char choice = char.Parse(Console.ReadLine().ToLower());

            switch (choice)
            {
                case 'n': result[0] = 0; result[1] = 0; goto StartGame;
                case 'e': return;
                default: return;
            }
        }
    }
}
