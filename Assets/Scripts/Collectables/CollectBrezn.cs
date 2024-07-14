using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectBrezn : MonoBehaviour
{
    public AudioSource Heal;
    public GameObject thePlayer;
    public int healAmount = 20;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (thePlayer.GetComponent<PlayerMove>().currentHealth < thePlayer.GetComponent<PlayerMove>().maxHealth)
            {
                Heal.Play();
                thePlayer.GetComponent<PlayerMove>().HealHealth(healAmount);

                this.gameObject.SetActive(false);
            }
        }
    }
    
}
