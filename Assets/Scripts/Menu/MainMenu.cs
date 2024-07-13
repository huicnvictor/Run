using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{


    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

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
