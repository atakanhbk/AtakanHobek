using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderController : MonoBehaviour
{
    /*
    void OnCollisionEnter(Collision collision)
    {
        // temas edilen objenin Rigidbody bileþenine eriþmek için GetComponent kullanýn
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

        // eðer temas edilen objede Rigidbody varsa, itme kuvveti uygulayýn
        if (rb != null)
        {
            // temas edilen objenin normal vektörüne göre itme kuvveti hesaplayýn
            Vector3 forceDirection = -collision.contacts[0].normal;
            float forceMagnitude = 10f; // itme kuvvetinin büyüklüðü
            Vector3 force = forceDirection * forceMagnitude;

            // itme kuvvetini uygulayýn
            rb.AddForce(force, ForceMode.Impulse);
        }
    }
    */
}
