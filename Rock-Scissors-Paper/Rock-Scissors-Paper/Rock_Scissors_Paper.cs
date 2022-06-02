using System;

namespace Rock_Scissors_Paper
{
    class Rock_Scissors_Paper
    {
        static void Main(string[] args)
        {            
            int[] result = new int[3];              // i0 = playerWins, i1 = computerWins, i2 == draw            
            string[] computerChoice = { "Rock", "Scissors", "Paper" };

            while (true)
            {                
                StartGame:

                Console.Clear();
                Console.WriteLine("Rock | Scissors | Paper");
                Console.WriteLine();
                
                Console.WriteLine($"Player: {result[0]} | Computer: {result[1]} | Draw: {result[2]}");
                Console.WriteLine();
                Console.Write("Choose: [R]ock, [S]cissors, [P]aper, [E]xit: ");
                char playerChoice = char.Parse(Console.ReadLine().ToLower());
                
                string player;                

                switch (playerChoice)
                {
                    case 'r':
                        player = "Rock";
                        break;
                    case 's':
                        player = "Scissors";
                        break;
                    case 'p':
                        player = "Paper";
                        break;
                    case 'e':
                        return;                        
                    default:                        
                        goto StartGame;
                        
                }

                Random rnd = new Random();
                int index = rnd.Next(0, 3);
                string computer = computerChoice[index];

                Console.WriteLine();
                Console.WriteLine($"{player} | {computer}");                

                switch (player, computer)
                {
                    case ("Rock", "Scissors"):
                    case ("Paper", "Rock"):
                    case ("Scissors", "Paper"):
                        Console.WriteLine("You Win!");
                        result[0]++;
                        break;
                    case ("Rock", "Paper"):
                    case ("Paper", "Scissors"):
                    case ("Scissors", "Rock"):
                        Console.WriteLine("Computer Win!");
                        result[1]++;
                        break;
                    default:
                        Console.WriteLine("Draw Game!");
                        result[2]++;
                        break;
                }

                Console.WriteLine();
                Console.WriteLine($"Current Result is: Player {result[0]} | Computer {result[1]} | Draw {result[2]}");
                Console.WriteLine();
                Console.WriteLine("Press 'Enter' to continue...");
                Console.ReadLine();
            }
        }
    }
}
