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
        if (other.gameObject.CompareTag("fuel") && _fuels.Count<=20)
        {
          //  StartCoroutine(FuelSpawn());
            
            other.gameObject.transform.SetParent(transform);
           // other.gameObject.tag = "Untagged";
            other.gameObject.transform.localPosition = new Vector3(0.15f, _fuels[_fuels.Count - 1].transform.localPosition.y+0.01f, -0.5f);
            other.gameObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            _fuels.Add(other.gameObject);
           

        }

        else if (other.gameObject.CompareTag("fuel") && _fuels.Count >= 20)
        {
            other.gameObject.transform.SetParent(transform);
            //StartCoroutine(FuelSpawn());
            other.gameObject.transform.localPosition = new Vector3(-0.15f, _fuels[_fuels.Count - 1].transform.localPosition.y - 0.01f, -0.5f);
            other.gameObject.GetComponent<Transform>().localScale = new Vector3(0.2f, 0.2f, 0.2f);
            _fuels.Add(other.gameObject);
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
        }


    }
  /*  IEnumerator FuelSpawn()
    {
        Instantiate(fuel, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
    }*/
}
