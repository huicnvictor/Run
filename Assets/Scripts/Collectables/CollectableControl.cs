using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectbalControl : MonoBehaviour
{
    public static int coinCount;
    public static int scoreCount;
    public GameObject coinCountDisplay;
    public GameObject scoreEndDisplay;
    public GameObject scoreVicDisplay;
  

    // Update is called once per frame
    void Update()
    {
        coinCountDisplay.GetComponent<TMP_Text>().text = "" + coinCount;
        scoreCount = coinCount * GameSettings.multiplier;
        scoreEndDisplay.GetComponent<TMP_Text>().text = "" + scoreCount;
        scoreVicDisplay.GetComponent<TMP_Text>().text = "" + scoreCount;
        Score();
    }
    void Score() {
        GameSettings.playerScore = scoreCount;
    }
}
