using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public int gravity;


    private void Start()
    {
        Physics.gravity = new Vector3(0, -gravity, 0);
    }
 
}
