using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "player")
        {
            Debug.Log("Hit Player");
        }
    }
}
