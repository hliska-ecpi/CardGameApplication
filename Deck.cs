/*
    Name
    Date
    Notes:
        This class creates and manages a standard 52-playing card deck.
        It supports shuffling and drawing cards utilize the Fisher-Yates method.
*/

using System.Security.Cryptography.X509Certificates;

public class Deck
{
    private static readonly Random rng = new Random();
    private List<Card> cards;
    private static readonly string[] Suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
    private static readonly string[] Ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

    //Default Constructor - build a new deck of standard 52 playing cards
    public Deck()
    {
        cards = new List<Card>();
        foreach (String suit in Suits)
        {
            for (int i = 0; i < Ranks.Length; i++)
            {
                int value = i + 2;
                if (Ranks[i] == "J" || Ranks[i] == "Q" || Ranks[i] == "K")
                {
                    value = 10;
                }
                else if (Ranks[i] == "A")
                {
                    value = 11;
                }
                cards.Add(new Card(suit, Ranks[i], value));
            }
        }
    }

    /* Method Name: Shuffle
       Input: None
       Output: None
       Notes: Shuffle all cards using Fisher-Yates algorithm
    */
    public void Shuffle()
    {
        int n = cards.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            var temp = cards[k];
            cards[k] = cards[n];
            cards[n] = temp;
        }
    }

    // Draw and remove the top card from the deck
    // Return null when deck is empty
    public Card DrawCard()
    {
        if (cards.Count == 0)
        {
            return null;
        }

        //Save the top card of the deck
        Card card = cards[0];

        //Remove that card from the deck
        cards.RemoveAt(0);

        //Return the top card pulled from the deck
        return card;
    }

    // Draw multiple cards at once
    public List<Card> DrawCard(int count)
    {
        List<Card> drawn = new List<Card>();
        for (int i = 0; i < count && cards.Count > 0; i++)
        {
            drawn.Add(DrawCard());
        }
        return drawn;
    }
}