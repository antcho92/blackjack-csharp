using System;
using System.Collections.Generic;

namespace BlackJack
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Prompt();
        }
        private static void Prompt()
        {
            System.Console.WriteLine("Choose from options:");
            System.Console.WriteLine("1: Start New Game");
            System.Console.WriteLine("q: Exits program");
            string InputLine;
            InputLine = Console.ReadLine();
            switch (InputLine)
            {
                case "1":
                    System.Console.WriteLine("Starting a new game");
                    Create();
                    break;
                case "q":
                    System.Environment.Exit(1);
                    break;
                default:
                    Prompt();
                    break;
            }
        }
        public static void Create()
        {
            Game currGame = new Game();
        }
    }
}
