using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEndPointData",menuName = "Create New End Point Data")]
public class EndPointData : ScriptableObject
{
    public float pullRadius; 
    public float pullForce; 
}
