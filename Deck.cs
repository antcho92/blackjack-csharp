using System;
using System.Collections.Generic;

namespace BlackJack
{
    public class Deck
    {
        List<Card> cards = new List<Card>();
        public Deck()
        {
            Reset();
        }
        public void Reset()
        {
            cards.Clear();
            string[] suits = { "Spades", "Clubs", "Diamonds", "Hearts" };
            // go through 1-13
            for (int i = 1; i <= 13; i++)
            {
                // go through the possible suits
                for (int j = 0; j < 4; j++)
                {
                    cards.Add(new Card(i, suits[j]));
                }
            }
        }
        // Method to get list of cards in deck
        public void PrintCards()
        {
            foreach (Card card in cards)
            {
                card.printCard();
            }
        }
        public void Shuffle()
        {
            Random r = new Random();
            for (int i = 0; i < cards.Count; i++)
            {
                int j = r.Next(i, cards.Count);
                Card temp = cards[i];
                cards[i] = cards[j];
                cards[j] = temp;
            }
        }
        public Card Deal()
        {
            Card newCard = cards[0];
            cards.RemoveAt(0);
            return newCard;
        }

    }
}
