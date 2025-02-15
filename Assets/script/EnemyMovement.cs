using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    float izquierda = -0.5f;
    float izquierdaExL = -0.2f;
    float speed = 3f;
    public Rigidbody2D rb;
    public bool rebaja;
    float currTime;
    float currTimeExL;
    float cooldown = 2f;
    float cooldownBL = 5f;
    public bool exPlosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rebaja)
        {
            rb.velocity = new Vector2(izquierda, rb.velocity.y);
            currTime += Time.deltaTime;
            if (currTime >= cooldown)
            {
                rebaja = false;
                currTime = 0f;
            }
        }

        if (exPlosion)
        {
            rb.velocity = new Vector2(izquierdaExL, rb.velocity.y);
            currTimeExL += Time.deltaTime;
            if (currTimeExL >= cooldownBL)
            {
                exPlosion = false;
                currTimeExL = 0f;
            }
        }
        else
        {
            rb.velocity = new Vector2(-1 * speed, rb.velocity.y);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Muro")
        {
            rebaja = true;            
        }
    }
    void OnTriggerStay2D(Collider2D collision){
        if(collision.gameObject.tag == "BOOM")
        {
            exPlosion = true;
        }
    }
}
