using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    Stack stack;
    private int[] smallOnes = { 1, 3, 5, 6, 8, 9, };
    
    private void Start()
    {
        
        stack = gameObject.GetComponent<Stack>();
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Border" && stack._fuels !=null )
        {
            for (int i = 0; i < stack._fuels.Count; i++)
            {
                stack._fuels[0].gameObject.transform.localPosition = new Vector3(2, 0, 0);
                stack._fuels[i].gameObject.transform.localPosition = new Vector3(stack._fuels[0].transform.localPosition.x - i*0.1f, 1, -0.5f);
                stack._fuels[i].gameObject.transform.localScale = new Vector3(0.3f,0.5f , 0.2f);
                //stack._fuels[smallOnes[smallOnes.Length.]].gameObject.transform.localScale = new Vector3(0, 0, 0);
            }
           
        }
    }
}
