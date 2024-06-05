using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    // The target object
    public Transform targetObject;

    // Defautl distance between the target and the player
    public Vector3 cameraOffset;

    //Smooth factor will use in Camera roation
    public float smoothFactor = 0.5f;

    //will check that the camera looked at on the target on not.
    public bool lookAtTarget = false;

    //Start is called before the first frame update
    void Start()
    {
        cameraOffset = transform.position - targetObject.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPosition = targetObject.transform.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPosition, smoothFactor);

        //Camera Roation Change
        if (lookAtTarget) { 
        transform .LookAt(targetObject);
        }
    }
}
