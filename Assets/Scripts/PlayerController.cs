using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float turnSpeed = 5.0f;
    public float horizontalInput;
    public GameObject terrain;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        //Move the player forward based on vertical input
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        //Rotates the car based on horizontal input
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
        transform.position = new Vector3(transform.position.x, terrain.transform.position.y + 101, transform.position.z);

    }
}
