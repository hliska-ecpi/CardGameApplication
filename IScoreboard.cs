/*
    Define an abstraction for a scoreboard system
*/

public interface IScoreboard
{
    void RecordResult(string gameName, bool playerWon); // Record the wins and losses of the player
    void ShowStats(); // Display a statistical summary
    void SaveToFile(string filename); // Save current stats to a file for persistant storage
    bool LoadFromFile(string filename); // Load stats from a previously existing file
}