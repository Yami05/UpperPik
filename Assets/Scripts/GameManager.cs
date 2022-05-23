using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject Level;
    [SerializeField] Vector3 spawnPosition;
    
   
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Level, spawnPosition, Quaternion.identity);
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
