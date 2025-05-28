/*
    Each player flip over the top card of their deck. The player with the highest card
    wins both cards. If the card values are tied, "war" is declared. Each player must place
    3 cards face-down and one more face-up during "war". The highest face-up card wins all
    of the cards; the game continues until one player has all the cards in the deck.
*/

public class War : ICardGame
{
    private Deck deck;
    private Queue<Card> playerDeck;
    private Queue<Card> computerDeck;
    private int roundCount;

    //Shuffle and split the deck between two players
    public void Start()
    {
        Console.WriteLine("=== WAR Game ===");
        Console.WriteLine("Each player draws one card per round, highest card wins!");
        Console.WriteLine("If tied, WAR is declared: place 3 face-down cards and 1 face-up card.");

        deck = new Deck();
        deck.Shuffle();

        var allCards = deck.DrawCard(52);

        //Split the deck into two queues for the player and computer
        playerDeck = new Queue<Card>(allCards.GetRange(0, 26));
        computerDeck = new Queue<Card>(allCards.GetRange(26, 26));

        roundCount = 0;
    }

    //Stub to fulfill Interface contract
    public void DealCards() { }

    //Execute the main loop of WAR - handle rounds, comparing cards, declaring WAR
    public void Play()
    {
        while (playerDeck.Count > 0 && computerDeck.Count > 0)
        {
            roundCount++;
            Console.WriteLine("Round #: " + roundCount);

            Card playerCard = playerDeck.Dequeue();
            Card computerCard = computerDeck.Dequeue();

            Console.WriteLine("You play: " + playerCard);
            Console.WriteLine("Computer plays: " + computerCard);

            if (playerCard.Value > computerCard.Value)
            {
                Console.WriteLine("You win this round!");
                playerDeck.Enqueue(playerCard);
                playerDeck.Enqueue(computerCard);
            }
            else if (playerCard.Value < computerCard.Value)
            {
                Console.WriteLine("Computer wins this round!");
                computerDeck.Enqueue(playerCard);
                computerDeck.Enqueue(computerCard);
            }
            else
            {
                //Initiate a WAR
                Console.WriteLine("WAR! Each player places 3 cards face-down and 1 face-up. \n Winner takes all!");

                List<Card> warCards = new List<Card> { playerCard, computerCard };

                //Check if both player have enough cards for war. Exit loop if not.
                if (playerDeck.Count < 4 || computerDeck.Count < 4)
                {
                    Console.WriteLine("A player does not have enough cards for WAR. GAME OVER!");
                    break;
                }

                //Assign WAR cards
                for (int i = 0; i < 3; i++)
                {
                    warCards.Add(playerDeck.Dequeue());
                    warCards.Add(computerDeck.Dequeue());
                }

                Card playerWarCard = playerDeck.Dequeue();
                Card computerWarCard = computerDeck.Dequeue();

                Console.WriteLine("Your WAR card: " + playerWarCard);
                Console.WriteLine("Computer's WAR card: " + computerWarCard);

                //Check for WAR winner
                if (playerWarCard.Value > computerWarCard.Value)
                {
                    Console.WriteLine("You win the WAR!");

                    //FOREACH datatype tempVariable IN CollectionsObject
                    foreach (Card c in warCards)
                    {
                        playerDeck.Enqueue(c);
                    }
                }
                else
                {
                    Console.WriteLine("Computer wins the WAR!");

                    foreach (Card c in warCards)
                    {
                        computerDeck.Enqueue(c);
                    }
                }
            }
        }
    }

    //Display the result of the War game
    public void ShowResult()
    {
        Console.WriteLine("\n=== WAR Game Over ===");
        if (playerDeck.Count > computerDeck.Count)
        {
            Console.WriteLine("You win the game!");
        }
        else if (playerDeck.Count < computerDeck.Count)
        {
            Console.WriteLine("Computer wins the game!");
        }
        else
        {
            Console.WriteLine("The game has tied!");
        }
    }
}