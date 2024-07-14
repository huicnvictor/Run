using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject charModel;
    public AudioSource crashThud;
    public int damageAmount = 20;

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(1);
        this.gameObject.GetComponent<BoxCollider>().enabled = true;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            StartCoroutine(Respawn());

            if (!thePlayer.GetComponent<PlayerMove>().shielded)
            {
                charModel.GetComponent<Animator>().Play("Hit On Side Of Body");
                crashThud.Play();
                thePlayer.GetComponent<PlayerMove>().TakeDamage(damageAmount);
            }
        }
    }
    
}
