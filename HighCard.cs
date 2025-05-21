/*
    This class implement the ICardGame interface to provide the logic of a simple
    card game. Each player draws one card. The player with the higher-value card wins.
*/

public class HighCard : ICardGame
{
    private Deck deck;
    private Card playerCard, computerCard;

    //Start the Highcard game by initializing and shuffling the deck and explaining the rules.
    public void Start()
    {
        Console.WriteLine("=== High Card Game ===");
        Console.WriteLine("Each player draws one card. Highest card wins!");
        deck = new Deck();
        deck.Shuffle();
    }

    //Deal one card to the player and the computer. Display the drawn cards to the user
    public void DealCards()
    {
        playerCard = deck.DrawCard();
        computerCard = deck.DrawCard();

        Console.WriteLine("You drew: " + playerCard);
        Console.WriteLine($"Computer drew: {computerCard}");
    }


    //No game decisions in High Card. Stub to fulfill interface "contract"
    public void Play()
    {
        // No user input is required to play this game
    }


    //Compare the card values and display the winner
    //NOTE: Called after DealCards and Play.
    public void ShowResult()
    {
        if (playerCard.Value > computerCard.Value)
        {
            Console.WriteLine("You Win!");
        }
        else if (playerCard.Value < computerCard.Value)
        {
            Console.WriteLine("Computer wins!");
        }
        else
        {
            Console.WriteLine("It is a tie!");
        }
    }
}