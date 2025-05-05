using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerInput;
    private float direction;


    public Rigidbody2D rb;

    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float acceleration;
    [SerializeField]
    private float decceleration;
    [SerializeField]
    private float velocityPower;
    [SerializeField]
    private float friction;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        playerInput = Input.GetAxis("Horizontal");


        if (playerInput >= 0f)
        {
            direction = 1;
        }
        if (playerInput <= -0f)
        {
            direction = -1;
        }
        if (playerInput == 0)
        {
            direction = 0;
        }
    }

    private void FixedUpdate()
    {
        //run start
        float targetSpeed = direction * movementSpeed;

        float speedDif = targetSpeed - rb.velocity.x;

        float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : decceleration;

        float movement = Mathf.Pow(Mathf.Abs(speedDif) * accelRate, velocityPower) * Mathf.Sign(speedDif);

        rb.AddForce(movement * Vector2.right);
        //run end
    }


}
