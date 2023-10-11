using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage = false;

    void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log("Hit");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.tag == "Package") && (!hasPackage))
        {
            hasPackage = true;
            Debug.Log("Package picked up");
        }

        if ((other.tag == "Customer") && (hasPackage))
        {
            Debug.Log("Package delivered");
            hasPackage = false;
        }
    }
}
