using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoundary : MonoBehaviour
{
    public static float leftside = -5.25f;
    public static float rightside = 5.25f;
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
