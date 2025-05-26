using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    private Rigidbody2D rb;
    public Movimiento player;
    private float basegravity;
    private float speedDash;

    [Header("Dash")]
    [SerializeField] private float dashingtime = 0.2f;
    [SerializeField] private float dashforce = 20f;
    [SerializeField] private float dashcd = 1f;
    public bool isdashing = false;
    public bool dashOnCD = false;
    public float timer = 0f;
    private float timercd = 0f;
    private float playerDirection;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        basegravity = rb.velocity.y;
        timercd = dashcd;
    }


    void Update()
    {
        if(player.horizontal < 0)
        {
            playerDirection = -1;
        }
        if (player.horizontal > 0)
        {
            playerDirection = 1;
        }

        if (Input.GetKeyDown(KeyCode.C) && !dashOnCD)
        {
            isdashing = true;

        }

        if (isdashing )
        {
            dash();
            dashOnCD = true;
        }

        if (dashOnCD)
        {
            timercd -= Time.deltaTime;
            if (timercd < 0)
            {
                timercd = dashcd;
                dashOnCD = false;
            }
        }

    }

    private void dash()
    {
            rb.velocity = new Vector2(dashforce * playerDirection, 0);
            timer += Time.deltaTime;
            if(timer >= dashingtime)
            {
                timer = 0f;
                isdashing = false;
            }
    }
}
