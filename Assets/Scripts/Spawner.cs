using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject Fuel;

    private void Start()
    {
        Instantiate(Fuel, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


     IEnumerator SpawnIt()
    {
       
     ;

        yield return new WaitForSeconds(2f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player")
        {
            Instantiate(Fuel, transform.position, Quaternion.identity);
        }
            
        



    }
}
