using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] GameObject Ryan;

    void LateUpdate()
    {
        transform.position = Ryan.transform.position + new Vector3 (0, 0, -10);    
    }
}
