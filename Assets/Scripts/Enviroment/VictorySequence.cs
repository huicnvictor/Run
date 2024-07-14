using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictorySequence : MonoBehaviour
{
    public GameObject liveScore;
    public GameObject victoryScreen;
    public GameObject fadeOut;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(victorySequence());
    }

    IEnumerator victorySequence()
    {
        yield return new WaitForSeconds(1);
        liveScore.SetActive(false);
        victoryScreen.SetActive(true);
        //yield return new WaitForSeconds(2);
        fadeOut.SetActive(true);


    }
}
