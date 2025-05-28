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

    //Save stat data to a file
    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var kvp in stats)
            {
                string line = $"{kvp.Key},{kvp.Value.wins},{kvp.Value.losses},{kvp.Value.rounds}";
                writer.WriteLine(line);
            }
        }
    }

    //Load stat data from a file
    public bool LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            return false;
        }
        else
        {
            stats.Clear();
            foreach (String line in File.ReadAllLines(filename))
            {
                string[] parts = line.Split(',');
                if (parts.Length == 4)
                {
                    string game = parts[0];
                    int wins = int.Parse(parts[1]);
                    int losses = int.Parse(parts[2]);
                    int rounds = int.Parse(parts[3]);

                    stats[game] = (wins, losses, rounds);
                }
            }

            return true;
        }

    }
}