/*
    This class implementsa simplified BlackJack game.
    Players draw cards to reach a total value close to 21 without going over.
    The dealer must draw until reaching a value of at least 17.
*/

public class BlackJack : ICardGame
{
    private Deck deck;
    private List<Card> playerHand, dealerHand;

    //Initialize and shuffle the deck of cards and explain rules to the player.
    public void Start()
    {
        Console.WriteLine("=== Blackjack ===");
        Console.WriteLine("Try to get as close to 21 as possible without going over.");

        deck = new Deck();
        deck.Shuffle();

        playerHand = new List<Card>();
        dealerHand = new List<Card>();
    }

    //Deals 2 cards to the player and dealer.
    //Display the player's hand and one visible dealer card
    public void DealCards()
    {
        playerHand.Add(deck.DrawCard());
        playerHand.Add(deck.DrawCard());

        dealerHand.Add(deck.DrawCard());
        dealerHand.Add(deck.DrawCard());

        Console.WriteLine($"Your hand: {string.Join(", ", playerHand)}");
        Console.WriteLine($"Dealer hand: {dealerHand[0]}");
    }

    //Handle game logic of hits/stands as well as dealer response
    //Player draws until they stand or bust (exceed 21 card value)
    //Dealer plays next
    public void Play()
    {
        string input;
        //Keep asking user to Hit or Stand until either 21 is BUSTED or player Stands
        while (HandValue(playerHand) < 21)
        {
            Console.Write("Hit or Stand? (h/s): ");
            input = Console.ReadLine();

            if (input.ToLower() == "h")
            {
                playerHand.Add(deck.DrawCard());
                Console.WriteLine($"Your hand: {string.Join(", ", playerHand)}");
            }
            else
            {
                break;
            }
        }

        Console.WriteLine($"Dealer hand: {string.Join(", ", dealerHand)}");
        while (HandValue(dealerHand) < 17)
        {
            dealerHand.Add(deck.DrawCard());
            Console.WriteLine($"Dealer draw: {dealerHand[^1]}");
        }
    }

    /*
        Calcuate the total value of cards in hand (adjust for Aces as needed 11 or 1)
        Parameters: hand - list of cards representing a player's hand
        Return: int - total numeric value of the hand
    */
    private int HandValue(List<Card> hand)
    {
        int total = 0;
        int aces = 0;

        //Adding each card's value one at a time
        foreach (Card card in hand)
        {
            total += card.Value;
            if (card.Rank == "A")
            {
                aces++;
            }
        }

        //Aces can count as 11 or 1, depending on if the card value keeps it <= 21
        while (total > 21 && aces > 0)
        {
            total -= 10;
            aces--;
        }

        return total;
    }

    //Display the final result of the game by comparing the player and dealer hands
    public void ShowResult()
    {
        int playerValue = HandValue(playerHand);
        int dealerValue = HandValue(dealerHand);

        Console.WriteLine("Your total is: " + playerHand);
        Console.WriteLine("The dealer total is: " + dealerHand);

        if (playerValue > 21)
        {
            Console.WriteLine("BUST! Dealer wins.");
        }
        else if (dealerValue > 21 || playerValue > dealerValue)
        {
            Console.WriteLine("You Win!");
        }
        else if (playerValue < dealerValue)
        {
            Console.WriteLine("Dealer Wins.");
        }
        else
        {
            Console.WriteLine("The Game Is A Tie!");
        }
    }
}