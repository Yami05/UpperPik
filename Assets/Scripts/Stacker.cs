using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stacker : MonoBehaviour
{
    public GameObject stack;

    // Update is called once per frame
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag==("fuel"))
        {
            GameObject s = Pool.singleton.Get("stack");
            if(s != null)
            {
                s.transform.position = this.transform.position + new Vector3(0, 0, -0.1f);
                s.SetActive(true);
            }
        }
    }
}
