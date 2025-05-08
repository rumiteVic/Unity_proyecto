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
    public bool exPlosion;

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
            speed = 0f;
        }
        else
        {
            speed = 20f;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyDamageSensor" || collision.gameObject.tag == "SpawnGround")
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyDamageSensor" || collision.gameObject.tag == "SpawnGround")
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
    }
    void OnTriggerExit2D(Collider2D collision){
        exPlosion = false;
    }
}