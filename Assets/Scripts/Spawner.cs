using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawn;
    
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        GameObject f = Pool.singleton.Get("fuel");
        if (f !=null)
        {

            f.transform.position = this.transform.position;
                f.SetActive(true);


        }
      
    }
}
