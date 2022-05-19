using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Finish : MonoBehaviour
{
    [SerializeField] private TextMeshPro typeText = null;
    [SerializeField] FinishLineColor finishLineColor = null;

    private void Start()
    {
        typeText.text = finishLineColor.typeMultiplier;
        GetComponent<Renderer>().material.color = finishLineColor.FinishLine;
    }
}
