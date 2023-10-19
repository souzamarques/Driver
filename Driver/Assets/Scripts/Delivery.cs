using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 packageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);
    SpriteRenderer spriteRenderer;

    bool hasPackage = false;
    [SerializeField] float destroyDelay = 0.7f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.tag == "Package") && (!hasPackage))
        {
            hasPackage = true;
            Debug.Log("Package picked up");
            spriteRenderer.color = packageColor;
            Destroy(other.gameObject, destroyDelay);
        }

        if ((other.tag == "Customer") && (hasPackage))
        {
            Debug.Log("Package delivered");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}
