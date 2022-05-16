using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    Stack stack;
     public int width;
    public List<GameObject> wing = new List<GameObject>();
    private void Start()
    {
        stack = gameObject.GetComponent<Stack>();
        for (int i = 0; i < width; i++)
        {
            Vector3 pos = new Vector3(i, 0, 0);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Border" && stack._fuels !=null )
        {
            foreach (GameObject fuel in stack._fuels.ToArray())
            {
                wing.Add(fuel);
                fuel.transform.localPosition = new Vector3(0, wing[wing.Count - 1].transform.localPosition.y + 0.01f, -0.5f);
            }

           
        }
    }
}
