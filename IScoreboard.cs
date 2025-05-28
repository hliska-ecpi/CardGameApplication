/*
    Define an abstraction for a scoreboard system
*/

public interface IScoreboard
{
    void RecordResult(string gameName, bool playerWon);
    void ShowStats();
}