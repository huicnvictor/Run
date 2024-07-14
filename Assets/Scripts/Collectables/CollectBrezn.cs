using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectBrezn : MonoBehaviour
{
    public AudioSource Heal;
    public GameObject thePlayer;
    public int healAmount = 20;


    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(1);
        this.gameObject.SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (thePlayer.GetComponent<PlayerMove>().currentHealth < thePlayer.GetComponent<PlayerMove>().maxHealth)
            {
                Heal.Play();
                thePlayer.GetComponent<PlayerMove>().HealHealth(healAmount);

                this.gameObject.SetActive(false);
                StartCoroutine(Respawn());
            }
        }
    }
    
}
