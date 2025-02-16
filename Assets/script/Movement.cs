using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    public float speed;

    public Rigidbody2D rb;
    public GameObject destination1;
    public GameObject destination2;
    public Collider2D col;
    private Transform currentDestination;
    Vector2 direction;
    public bool rebaja;
    float currTime;
    float cooldown = 2f;

    float currTimeExL;
    float cooldownBL = 9f;
    public bool exPlosion;

    public bool expl2;
    float currTimeExL2;
    float cooldownBL2 = 9f;
    float totalDamage;

    public bool jau;
    float currTimeJau;
    float cooldownJau = 3f;

    // Start is called before the first frame update
    void Start()
    {
        currentDestination = destination1.transform;
        rb = GetComponent<Rigidbody2D>();
        direction = (currentDestination.position - transform.position).normalized;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (rebaja)
        {
            speed = 0.5f;
            currTime += Time.deltaTime;
            if (currTime >= cooldown)
            {
                rebaja = false;
                currTime = 0f;
            }
        }

        else if (exPlosion)
        {
            speed = 0.2f;
            col.enabled = false;
            currTimeExL += Time.deltaTime;
            if (currTimeExL >= cooldownBL)
            {
                col.enabled = true;
                exPlosion = false;
                currTimeExL = 0f;
            }
        }
        else if(expl2)
        {
            speed = 0f;
            currTimeExL2 += Time.deltaTime;
            if (currTimeExL2 >= cooldownBL2)
            {
                expl2 = false;
                currTimeExL2 = 0f;
            }
        }
        else if(jau)
        {
            speed = 0f;
            currTimeJau += Time.deltaTime;
            if (currTimeJau >= cooldownJau)
            {
                jau = false;
                currTimeJau = 0f;
            }
        }
        else
        {
            col.enabled = true;
            speed = 5f;
        }
        
        rb.velocity = direction*speed;
        ChangeDirection();
    }

    void ChangeDirection()
    {
        if (Vector2.Distance(transform.position, currentDestination.position) < 1.5f && currentDestination.position == destination1.transform.position)
        {
            currentDestination = destination2.transform;
            direction = (currentDestination.position - transform.position).normalized;
        }
        else if(Vector2.Distance(transform.position, currentDestination.position) < 1.5f && currentDestination.position == destination2.transform.position)
        {
            currentDestination = destination1.transform;
            direction = (currentDestination.position - transform.position).normalized;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if(collision.tag == "Player")
        {
            collision.GetComponent<Movimiento>().Muerte();
        }
        else if(collision.gameObject.tag == "BOOM" || collision.gameObject.tag == "BOOMOSC")
        {
            totalDamage = 7f;
            Muerte();
        }
        else if(collision.gameObject.tag == "Proyectil" || collision.gameObject.tag == "ProyectilOscuro" ){
            totalDamage = 1f;
            Muerte();
        }
        else if(collision.gameObject.tag == "AttackPlayer")
        {
            totalDamage = 3f;
            Muerte();
        }
    }
    void OnTriggerStay2D(Collider2D collision){

        if (collision.gameObject.tag == "Muro")
        {
            rebaja = true;
            totalDamage = 0.03f;
            Muerte();            
        }
        else if(collision.gameObject.tag == "BOOM")
        {
            exPlosion = true;
        }
        else if(collision.gameObject.tag == "BOOMOSC")
        {
            expl2 = true;
        }
        else if(collision.gameObject.tag == "Jaula")
        {
            jau = true;
        }
    
    }
    public void Muerte()
    {
        EnemyLife.instance.currentVidas = EnemyLife.instance.currentVidas - totalDamage;
        if (EnemyLife.instance.currentVidas < 0)
        {
            Destroy(gameObject);
        }
    }
}
