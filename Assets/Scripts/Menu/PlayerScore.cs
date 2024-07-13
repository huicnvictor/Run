[System.Serializable]
public class PlayerScore
{
    public string playerName;
    public int highScore;

    public PlayerScore(string name, int score)
    {
        playerName = name;
        highScore = score;
    }
}
