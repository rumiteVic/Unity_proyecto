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
    public bool izquierda;

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
        rb = GetComponent<Rigidbody2D>();

         if (izquierda) 
        {
            rb.velocity = new Vector2(speed * (-1), rb.velocity.y);
        }
        if (!izquierda) 
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        } 
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
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyDamageSensor")
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
        if (collision.gameObject.tag == "EnemyDamageSensor")
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