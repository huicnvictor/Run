using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    public AudioSource Collect;
    public GameObject thePlayer;

    
    void OnTriggerEnter(Collider other)
    {
        Collect.PlayOneShot(Collect.clip);
        CollectbalControl.scoreCount += 1;
        this.gameObject.SetActive(false);
    }


}
