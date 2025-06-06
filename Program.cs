﻿/*
    This class displays the list of available games and runs the selected option.
*/

class Program
{
    static void Main(string[] args)
    {
        ICardGame game = null;
        string choice, again, statsFile = "scoreboard.txt";
        bool playAgain = true;
        IScoreboard scoreboard = new Scoreboard();
        scoreboard.LoadFromFile(statsFile);

        while (playAgain)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== Card Game Console! ===");
            Console.WriteLine("Choose a game to play:");
            Console.WriteLine("1. High Card");
            Console.WriteLine("2. Blackjack");
            Console.WriteLine("3. WAR");
            Console.WriteLine("4. Show Scoreboard");
            Console.WriteLine("0. EXIT");
            Console.ResetColor();

            //Gather user input from menu options
            Console.WriteLine("Enter Selection: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    game = new HighCard();
                    break;
                case "2":
                    game = new BlackJack();
                    break;
                case "3":
                    game = new War();
                    break;
                case "4":
                    scoreboard.ShowStats();
                    Console.ReadKey();
                    continue;
                case "0":
                    playAgain = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Press any key to try again...");
                    Console.ReadKey();
                    continue;
            }

            Console.Clear();
            game.Start();
            game.DealCards();
            game.Play();
            game.ShowResult(scoreboard);

            Console.Write("\n\nWould you like to play another game? (Y/N): ");
            again = Console.ReadLine();
            playAgain = again.Trim().ToLower() == "y";
        }

        scoreboard.SaveToFile(statsFile);
        Console.WriteLine("Thank you for playing!");
    }
}