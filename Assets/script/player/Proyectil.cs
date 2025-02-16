using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public GameObject bala;
    public GameObject player;
    public Rigidbody2D rb;
    public float speed = 5;
    float horizontal;
    float izDe;
    bool derecha = true;


    // Start is called before the first frame update
    void Start()
    {
        horizontal = Input.GetAxis("Horizontal");
        if (horizontal < 0)
        {
            derecha = false;
        }
        else if (horizontal > 0)
        {
            derecha = true;
        }

        if (derecha)
        {
            izDe = 1f;
        }
        if (!derecha)
        {
            izDe = -1f;
        }
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = new Vector2(izDe * speed, rb.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemy")
        {
            Destroy(gameObject);
        }
        if (collision.tag == "SpawnGround")
        {
            Destroy(gameObject);
        }
    }
}