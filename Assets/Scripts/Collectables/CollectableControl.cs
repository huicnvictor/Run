using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectbalControl : MonoBehaviour
{
    public static int scoreCount;
    public GameObject scoreCountDisplay;
    public GameObject scoreEndDisplay;
    public GameObject scoreVicDisplay;


    // Update is called once per frame
    void Update()
    {
        scoreCountDisplay.GetComponent<TMP_Text>().text = "" + scoreCount;
        scoreEndDisplay.GetComponent<TMP_Text>().text = "" + scoreCount;
        scoreVicDisplay.GetComponent<TMP_Text>().text = "" + scoreCount;    
    }
}
