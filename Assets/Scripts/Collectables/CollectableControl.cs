using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectbalControl : MonoBehaviour
{
    public static int scoreCount;
    public GameObject scoreCountDisplay;
   

    // Update is called once per frame
    void Update()
    {
        scoreCountDisplay.GetComponent<Text>().text = "" + scoreCount;
    }
}
