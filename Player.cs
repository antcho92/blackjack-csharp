using System;
using System.Collections.Generic;

namespace BlackJack
{
    public class Player
    {
        public string name;
        public bool bust;
        public bool stay;
        List<Card> hand = new List<Card>();

        public Player(string givenName)
        {
            name = givenName;
            stay = false;
            bust = false;
        }
        public Card Draw(Deck deck)
        {
            Card newCard = deck.Deal();
            hand.Add(newCard);
            return newCard;
        }
        public List<Card> getHand()
        {
            return hand;
        }
        public void showHand()
        {
            System.Console.WriteLine($"{name}'s Hand:");
            foreach (Card card in hand)
            {
                card.printCard();
            }
        }
        public bool discard(Card card)
        {
            if (hand.Contains(card))
            {
                hand.Remove(card);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}