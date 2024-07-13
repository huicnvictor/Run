using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScoreManager : MonoBehaviour
{
    public List<PlayerScore> playerScores = new List<PlayerScore>();

    private void Start()
    {
        // 加载已保存的分数记录（如果有的话）
        LoadScores();
    }

    public void RecordScore(string playerName, int score)
    {
        // 检查是否已有该玩家的记录
        PlayerScore existingScore = playerScores.Find(p => p.playerName == playerName);

        if (existingScore != null)
        {
            // 如果有，更新最高分
            if (score > existingScore.highScore)
            {
                existingScore.highScore = score;
            }
        }
        else
        {
            // 如果没有，添加新的记录
            playerScores.Add(new PlayerScore(playerName, score));
        }

        // 根据分数排序（从高到低）
        playerScores = playerScores.OrderByDescending(p => p.highScore).ToList();

        // 保存更新后的分数记录
        SaveScores();
    }

    void SaveScores()
    {
        // 使用 PlayerPrefs 或其他方式保存分数记录
        string json = JsonUtility.ToJson(new ScoresWrapper(playerScores));
        PlayerPrefs.SetString("PlayerScores", json);
        PlayerPrefs.Save();
    }

    void LoadScores()
    {
        // 加载保存的分数记录
        if (PlayerPrefs.HasKey("PlayerScores"))
        {
            string json = PlayerPrefs.GetString("PlayerScores");
            ScoresWrapper wrapper = JsonUtility.FromJson<ScoresWrapper>(json);
            playerScores = wrapper.playerScores;
        }
    }
}

[System.Serializable]
public class ScoresWrapper
{
    public List<PlayerScore> playerScores;

    public ScoresWrapper(List<PlayerScore> scores)
    {
        playerScores = scores;
    }
}