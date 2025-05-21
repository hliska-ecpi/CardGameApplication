/*
    This class defines a standard structure for all card games. Any class implementing
    this interface MUST override and provide behavior for:
    Starting the Game
    Dealing Cards
    Playing the Game
    Displaying Results
*/

public interface ICardGame
{
    void Start(); //Initialize and introduce the game
    void DealCards(); //Handle card distribution
    void Play(); //Run game-specific logic
    void ShowResult(); //Display winning information
}