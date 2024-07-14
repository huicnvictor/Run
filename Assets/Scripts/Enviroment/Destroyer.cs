using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public string parentName;

    // Update is called once per frame
    void Start()
    {
        parentName = transform.name;
        StartCoroutine(DestroyClone());
    }

    IEnumerator DestroyClone()
    {
        yield return new WaitForSeconds(180);
        if(parentName == "Section(Clone)")
        {
            Destroy(gameObject);
        }
        
    }
}
    