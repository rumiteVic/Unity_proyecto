using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbreteSesamo : MonoBehaviour
{
    public Rigidbody2D rb;
    bool vuela = false;
    float currTim = 0f;
    float cooldown = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(vuela){
            rb.gravityScale = -50f;
            currTim += Time.deltaTime;
            if(currTim >= cooldown){
                currTim = 0f;
                vuela = false;
                rb.gravityScale = 40f;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Gravitacional"){
            vuela = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Ground" || collision.gameObject.tag == "SpawnGround"){
            rb.gravityScale = 1f;
        }
    }
}
