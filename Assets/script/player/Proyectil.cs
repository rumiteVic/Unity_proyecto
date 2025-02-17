using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public GameObject bala;
    public Rigidbody2D rb;
    public float speed = 20;
    float horizontal;
    float izDe;
    bool derecha = true;

    float currTimeExL;
    float cooldownBL = 9f;
    public bool exPlosion;

    public bool expl2;
    float currTimeExL2;
    float cooldownBL2 = 9f;
    float totalDamage;

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
         if (exPlosion)
        {
            speed = 0.2f;
            currTimeExL += Time.deltaTime;
            if (currTimeExL >= cooldownBL)
            {
                exPlosion = false;
                currTimeExL = 0f;
            }
        }
        else if (expl2)
        {
            speed = 0f;
            currTimeExL2 += Time.deltaTime;
            if (currTimeExL2 >= cooldownBL2)
            {
                expl2 = false;
                currTimeExL2 = 0f;
            }
        }
        else
        {
            speed = 20f;
        }

        rb.velocity = new Vector2(izDe * speed, rb.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "SpawnGround")
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "SpawnGround")
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {

       if (collision.gameObject.tag == "BOOM")
        {
            exPlosion = true;
        }
        else if (collision.gameObject.tag == "BOOMOSC")
        {
            expl2 = true;
        }

    }
}