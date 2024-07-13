using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectBeer : MonoBehaviour
{
    public AudioSource Collect;
    public GameObject thePlayer;
    
    void OnTriggerEnter(Collider other)
    {
  
        Collect.Play();
        this.gameObject.SetActive(false);
        thePlayer.GetComponent<PlayerMove>().Shield();
    }

    
}
