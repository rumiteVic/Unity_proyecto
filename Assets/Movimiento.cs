using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    float horizontal;
    float vertical;
    public float speed;
    public float impulso;
    public bool suelo;

    public Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
   
        horizontal = Input.GetAxis("Horizontal");
        
        Vector3 direccion = new Vector3(horizontal, 0);

        transform.position += direccion * speed * Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.UpArrow) && suelo)
        {
            rb.AddForce(Vector2.up * impulso, ForceMode2D.Impulse);
            suelo = false;
        }
    }
    void OnCollisionEnter2D(Collision2D collision){
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Ground"){
            suelo = true;
        }
    }
}
