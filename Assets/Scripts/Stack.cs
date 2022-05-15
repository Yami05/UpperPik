using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stack : MonoBehaviour
{
    [SerializeField] private TMP_Text _fuelCountText = null;

    public List<GameObject> _fuels = new List<GameObject>();
   

   
   
    void Update()
    {
        FuelCountText();
    }

    private void FuelCountText()
    {
        _fuelCountText.text = (_fuels.Count-1).ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("fuel"))
        {
            
            other.gameObject.transform.SetParent(transform);
           
            other.gameObject.transform.localPosition = new Vector3(0, _fuels[_fuels.Count - 1].transform.localPosition.y+0.01f, -0.5f);
            other.gameObject.GetComponent<Transform>().localScale = new Vector3(0.05f, 0.05f, 0.05f);
            

            _fuels.Add(other.gameObject);
        }
        if (other.gameObject.CompareTag("Border"))
        {
            
        }
    }
}
