using System;
using System.Collections.Generic;

namespace BlackJack
{
    public class Card
    {
        public string Suit {get; set;}
        public int numerical_value {get; set;}
        public string value {
            get {
                switch(numerical_value)
                {
                    case 1:
                        return "Ace";
                    case 11:
                        return "Jack";
                    case 12:
                        return "Queen";
                    case 13:
                        return "King";
                    default:
                        return numerical_value.ToString();
                }
            }
        }
        public Card(int numVal, string newSuit)
        {
            numerical_value = numVal;
            Suit = newSuit;
        }
        public void printCard()
        {
            System.Console.WriteLine("   -" + value + " of " + Suit);
        }
    }
}