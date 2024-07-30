using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{


    private TMP_InputField nameInputField;

    private void Start()
    {
        if (nameInputField == null)
        {
            nameInputField = GetComponentInChildren<TMP_InputField>();
        }
    
}
    public void PlayGame()
    {
        if (nameInputField != null)
        {
            // 获取玩家输入的名字
            string playerName = nameInputField.text;

            // 在 GameSettings 中保存玩家名字（假设 GameSettings 是一个静态类）
            GameSettings.playerName = playerName;
            Debug.Log(GameSettings.playerName);

            // 加载下一个场景（假设下一个场景在当前场景的 buildIndex + 1）
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            CollectbalControl.coinCount = 0;
        }
        else
        {
            Debug.LogWarning("InputField not found under Canvas.");
        }

    }

    public void Back2Menu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }
    public void QuitGame()
    {
        Debug.Log("Quit is working");
        Application.Quit();
    }
}
