using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossStateMachine : MonoBehaviour
{
    // Start is called before the first frame update

    public enum slimeStates { IDLE, MOVING };
    public slimeStates currentState = slimeStates.IDLE;
    Rigidbody2D rb;
    public Collider2D ground;
    private float counter;
    public bool isGrounded;
    public float force;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case slimeStates.IDLE:
                updateIdle();
                break;

            case slimeStates.MOVING:
                updateMoving();
                break;

            default: break;
        }
    }

    void updateIdle()
    {

        counter += Time.deltaTime;

        if (counter >= 3f)
        {
            counter = 0;
            currentState = slimeStates.MOVING;
        }
    }
    void updateMoving()
    {

        if (isGrounded)
        {
            isGrounded = false;
            rb.velocity = new Vector3(force * -1, force, 0);
            currentState = slimeStates.IDLE;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
        rb.velocity = Vector3.zero;
    }
}