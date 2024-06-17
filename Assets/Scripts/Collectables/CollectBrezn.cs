using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectBeer : MonoBehaviour
{
    public AudioSource Collect;

    void OnTriggerEnter(Collider other)
    {
            Collect.Play();
            this.gameObject.SetActive(false);
    }
    
}
