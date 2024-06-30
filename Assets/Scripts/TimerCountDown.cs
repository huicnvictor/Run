using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class TimerCountDown : MonoBehaviour
{
    public GameObject textDisplay;
    public int secondsLeft = 180;
    public bool takingAway = false;

    public void Start()
    {
        //textDisplay.GetComponent<Text>().text = secondsLeft +"sec";
        textDisplay.GetComponent<Text>().text = "0" + (secondsLeft / 60) + ":0" + (secondsLeft % 60);
    }

    public void Update() {

        if (takingAway == false && secondsLeft > 0) {
            StartCoroutine(TimerTake());
        }
    }
    IEnumerator TimerTake() {
    takingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        if ((secondsLeft % 60)<10) {
            textDisplay.GetComponent<Text>().text = "0" + (secondsLeft / 60) + ":0" + (secondsLeft % 60);
        }
        else { textDisplay.GetComponent<Text>().text = "0" + (secondsLeft / 60) + ":" + (secondsLeft % 60); }
      
           // secondsLeft + "sec";
        takingAway = false;
    }

}
