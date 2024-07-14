using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    public AudioSource Collect;
    public GameObject thePlayer;

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(1);
        this.gameObject.SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Collect.PlayOneShot(Collect.clip);
            CollectbalControl.coinCount += 1;
            this.gameObject.SetActive(false);
            StartCoroutine(Respawn());
        }
    }


}
