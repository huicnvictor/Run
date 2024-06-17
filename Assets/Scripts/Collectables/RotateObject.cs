using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotateSpeed = 1.0f;

    void Update()
    {
        // use Time.deltaTime 
        transform.Rotate(0, rotateSpeed * Time.deltaTime * 360, 0, Space.World);
    }
}