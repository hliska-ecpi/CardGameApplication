/*
    Implement IScoreBoard for tracking stats of all game types.
*/

public class Scoreboard : IScoreboard
{
    private Dictionary<string, (int wins, int losses, int rounds)> stats;

    //Default Constructor
    public Scoreboard()
    {
        stats = new Dictionary<string, (int, int, int)>();
    }

    // Record the results of a completed game
    public void RecordResult(string gameName, bool playerWon)
    {
        if (!stats.ContainsKey(gameName))
        {
            stats[gameName] = (0, 0, 0);
        }

        var (wins, losses, rounds) = stats[gameName];
        rounds++;

        if (playerWon)
        {
            wins++;
        }
        else
        {
            losses++;
        }

        stats[gameName] = (wins, losses, rounds);
    }

    public void ShowStats()
    {
        Console.WriteLine("\n\n===Scoreboard ===");
        foreach (var kvp in stats)
        {
            string game = kvp.Key;

            var (wins, losses, rounds) = kvp.Value;
            Console.WriteLine($"{game}: {wins} Wins, {losses} Losses, {rounds} Rounds");
        }

        Console.WriteLine("========================\n\n");
    }
}