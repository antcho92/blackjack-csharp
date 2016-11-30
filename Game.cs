using System;
using System.Collections.Generic;

namespace BlackJack
{
    public class Game
    {
        Deck currDeck;
        Player playerOne;
        Player playerTwo;
        public Game()
        {
            currDeck = new Deck();
            currDeck.Shuffle();
            playerOne = new Player("playerOne");
            playerTwo = new Player("playerTwo");
            gameStart();
            Round();
        }
        public void Round()
        {
            if (playerOne.stay == false)
            {
                Prompt(playerOne);
            }
            if (playerTwo.stay == false)
            {
                Prompt(playerTwo);
            }
            Calculate(playerOne);
            Calculate(playerTwo);
            ShowPlayers();
            if (playerOne.bust == true || playerTwo.bust == true)
            {
                EndGame();
            }
            else if (playerOne.stay == true && playerTwo.stay == true)
            {
                EndGame();
            }
            else
            {
                Round();
            }
        }
        public void gameStart()
        {
            playerOne.Draw(currDeck);
            playerTwo.Draw(currDeck);
            playerOne.Draw(currDeck);
            playerTwo.Draw(currDeck);
            ShowPlayers();
        }
        public void EndGame()
        {
            if (playerOne.bust == true && playerTwo.bust == false)
            {
                System.Console.WriteLine("Player two wins!");
            }
            else if (playerTwo.bust == true && playerOne.bust == false)
            {
                System.Console.WriteLine("Player one wins!");
            }
            else
            {
                if (Calculate(playerOne) > Calculate(playerTwo))
                {
                    System.Console.WriteLine("Player one wins!");
                }
                else
                {
                    System.Console.WriteLine("Player two wins!");

                }
            }
            System.Environment.Exit(1);
        }
        public void ShowPlayers()
        {
            playerOne.showHand();
            System.Console.WriteLine("    Count: " + Calculate(playerOne).ToString());
            playerTwo.showHand();
            System.Console.WriteLine("    Count: " + Calculate(playerTwo).ToString());
        }
        public void hit(Player player)
        {
            player.Draw(currDeck);
        }
        public int Calculate(Player player)
        {
            int count = 0;
            int aceCount = 0;
            List<Card> hand = player.getHand();
            foreach (Card card in hand)
            {
                if (card.numerical_value > 10)
                {
                    count += 10;
                }
                else if (card.numerical_value == 1)
                {
                    aceCount++;
                }
                else
                {
                    count += card.numerical_value;
                }
            }
            if (aceCount > 0)
            {
                if (count < 11 && aceCount == 1)
                {
                    count += 11;
                }
                else
                {
                    count += aceCount;
                }
            }
            if (count > 21)
            {
                player.bust = true;
            }
            return count;
        }
        private void Prompt(Player thisPlayer)
        {
            System.Console.WriteLine($"Options for {thisPlayer.name}");
            System.Console.WriteLine("1: Hit Me");
            System.Console.WriteLine("2: Stay");
            System.Console.WriteLine("q: Exits program");
            string InputLine = Console.ReadLine();
            switch (InputLine)
            {
                case "1":
                    hit(thisPlayer);
                    break;
                case "2":
                    thisPlayer.stay = true;
                    break;
                case "q":
                    System.Environment.Exit(1);
                    break;
                default:
                    Prompt(thisPlayer);
                    break;
            }
        }
    }
}