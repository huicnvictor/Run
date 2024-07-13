using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject charModel;
    public AudioSource crashThud;
    public int damageAmount = 20;

    void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        
        if(!thePlayer.GetComponent<PlayerMove>().shielded)
        { 
            charModel.GetComponent<Animator>().Play("Hit On Side Of Body");
            crashThud.Play();
            thePlayer.GetComponent<PlayerMove>().TakeDamage(damageAmount);
        }

    }
    
}
