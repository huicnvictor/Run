using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public ScoreManager scoreManager;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        // 显示排行榜
        UpdateScoreDisplay();
    }

    void UpdateScoreDisplay()
    {
        string displayText = "High Scores:\n";
        for (int i = 0; i < scoreManager.playerScores.Count; i++)
        {
            displayText += $"{i + 1}. {scoreManager.playerScores[i].playerName}: {scoreManager.playerScores[i].highScore}\n";
        }
        scoreText.text = displayText;
    }
}