using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoundary : MonoBehaviour
{
    public static float leftside = -3.5f;
    public static float rightside = 3.5f;
    public float internalleft;
    public float internalright;
    void Start()
    {
        internalleft = leftside;
        internalright = rightside;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
