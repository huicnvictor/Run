using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectBrezn : MonoBehaviour
{
    public AudioSource Collect;
    public GameObject thePlayer;
    public int healAmount = 20;

    void OnTriggerEnter(Collider other)
    {
            Collect.Play();
            this.gameObject.SetActive(false);
            thePlayer.GetComponent<PlayerMove>().HealHealth(healAmount);
    }
    
}
