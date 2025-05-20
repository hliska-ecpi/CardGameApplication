/*
    Name: Haylee
    Date: Current/Submission
    Notes: This class represents a single playing card in a deck of cards.
           Each card has a suit and a numeric value.
*/

public class Card
{
    public string Suit { get; set; }
    public string Rank { get; set; }
    public int Value { get; set; }

    //Overloaded Constructor
    public Card(string suit, string rank, int value)
    {
        Suit = suit;
        Rank = rank;
        Value = value;
    }

    //Overrides the base ToString() method to state a card's face
    public override string ToString()
    {
        return $"{Rank} of {Suit}";
    }

    //Overloaded version of the ToString() method to state card's value
    public string ToString(bool showValue)
    {
        return showValue ? $"{Rank} of {Suit} (Value: {Value})"
                         : ToString();
    }


}