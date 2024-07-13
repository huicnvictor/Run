using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRunSequence : MonoBehaviour
{
    public GameObject liveDis;
    public GameObject endScreen;
    public GameObject fadeOut;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EndSequence());
    }

    IEnumerator EndSequence() 
    {
        yield return new WaitForSeconds(1);
        liveDis.SetActive(false);
        endScreen.SetActive(true);
        //yield return new WaitForSeconds(2);
        fadeOut.SetActive(true);


    }
}
