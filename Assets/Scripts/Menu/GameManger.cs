using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ScoreManager scoreManager;
    public string currentPlayerName;
    public int currentScore;

    public void GameOver()
    {
        // 游戏结束时调用，记录分数
        scoreManager.RecordScore(currentPlayerName, currentScore);
    }
}
