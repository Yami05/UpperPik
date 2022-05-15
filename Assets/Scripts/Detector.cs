using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
  

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="fuel")
        {
            other.gameObject.transform.localPosition = new Vector3(10,  0.01f, -0.5f);
        }
    }
}
