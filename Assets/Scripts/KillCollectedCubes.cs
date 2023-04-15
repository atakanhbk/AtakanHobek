using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCollectedCubes : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Cube"))
        {
         KillWithDelay(other.gameObject);
        }
    }

    void KillWithDelay(GameObject otherObject)
    {
            Destroy(otherObject.gameObject);
    }
}
