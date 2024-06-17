using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 4;
    public float turnSpeed = 4;
    static public bool canMove = false;
    public bool isJumping = false;
    public bool comingDown = false;
    public GameObject playerObject;


    void Update()
    {

        //Move the player forward based on vertical input
        transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.World);



        //Keep player in the Boundary
        if (canMove == true)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                if (this.gameObject.transform.position.x > LevelBoundary.leftside)
                { transform.Translate(Vector3.left * Time.deltaTime * turnSpeed); 
                }
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                if (this.gameObject.transform.position.x < LevelBoundary.rightside)
                { transform.Translate(Vector3.left * Time.deltaTime * turnSpeed * -1); 
                }
            }
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space))
            {
                if (isJumping == false)
                {
                    isJumping = true;
                    playerObject.GetComponent<Animator>().Play("Running Jump");
                    StartCoroutine(JumpSequence());
                }
            }
            
            }


            if (isJumping == true)
            {
                if (comingDown == false)
                {
                    transform.Translate(Vector3.up * Time.deltaTime * 3, Space.World);
                }

                if (comingDown == true)
                {
                    transform.Translate(Vector3.down * Time.deltaTime * 3, Space.World);
                }

            }
        }


    IEnumerator JumpSequence()
    {
        yield return new WaitForSeconds(0.45f);
        comingDown = true;
        yield return new WaitForSeconds(0.45f);
        isJumping = false;
        comingDown = false;
        playerObject.GetComponent<Animator>().Play("Standard Run");
    }
}