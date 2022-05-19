using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="New Finish Line",menuName ="Finish Part")]
public class FinishLineColor : ScriptableObject
{
    public Color FinishLine = Color.blue;
    public string typeMultiplier = "type";
}
