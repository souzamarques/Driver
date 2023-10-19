using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 180f;
    [SerializeField] float moveSpeed = 15f;
    [SerializeField] float boostSpeed = 25f;
    [SerializeField] float slowSpeed = 10f;

    private float originalMoveSpeed;
    private bool isBoosted = false;
    private float boostDuration = 7f;
    private float timeBoost = 0f;

    private bool isSlowed;
    private float slowDuration = 3f;
    private float timeSlow = 0f;

    void Start() 
    {
        originalMoveSpeed = moveSpeed;    
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);

        if(isBoosted)
        {
            timeBoost += Time.deltaTime;

            if (timeBoost >= boostDuration)
            {
                isBoosted = false;
                moveSpeed = originalMoveSpeed;
            }
        }

        if(isSlowed)
        {
            timeSlow += Time.deltaTime;

            if(timeSlow >= slowDuration)
            {
                isSlowed = false;
                moveSpeed = originalMoveSpeed;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Boost")
        {
            moveSpeed = boostSpeed;
            isBoosted = true;
            timeBoost = 0f;
        }    
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        moveSpeed = slowSpeed;    
        isSlowed = true;
        timeSlow = 0f;
    }
}
