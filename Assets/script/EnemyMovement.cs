using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    float izquierda = -1;
    float speed = 3f;
    public Rigidbody2D rb;
    public bool rebaja;
    float currTime;
    float cooldown = 2f;
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
                Debug.Log("what");
                rebaja = false;
                currTime = 0f;
            }
        }
        else
        {
            rb.velocity = new Vector2(izquierda * speed, rb.velocity.y);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Muro")
        {
            rebaja = true;            
        }
    }
}
