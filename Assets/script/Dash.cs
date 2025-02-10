using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    private Rigidbody2D rb;
    private Movimiento player;
    private float basegravity;

    [Header("Dash")]
    [SerializeField] private float dashingtime = 0.2f;
    [SerializeField] private float dashforce = 20f;
    [SerializeField] private float timecandash = 1f;
    private bool isdashing;
    private bool candash = true;
    public bool Isdashing => isdashing; 

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        basegravity = rb.gravityScale;
     
    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.C))
        {
            StartCoroutine(dash()); 
        }

    }

    private IEnumerator dash()
    {
        if (player.horizontal != 0 && candash)
        {
            //hola

            isdashing = true;
            candash = false;
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(dashforce, 0f);
            yield return new WaitForSeconds(dashingtime);
            isdashing = false;
            rb.gravityScale = basegravity;
            yield return new WaitForSeconds(timecandash);
            candash = true;

        }
    }

}

