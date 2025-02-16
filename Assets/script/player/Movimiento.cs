using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float horizontal;
    float vertical;
    public float speed;
    public float impulso;
    public bool suelo;
    public bool jump = false;
    public Rigidbody2D rb;
    public Collider2D player;
    public HabilidadesSombra sombra;
    public ChangeLight change;
    private Dash playerdash;
    public GameObject player1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerdash = GetComponent<Dash>();
        player = GetComponent<Collider2D>();
        player.isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        if (horizontal > 0){
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
            transform.localRotation = Quaternion.Euler(0,0,0);
        }
        if (horizontal < 0)
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
            transform.localRotation = Quaternion.Euler(0,180,0);
        }
        if (horizontal == 0)
        {
            rb.velocity = new Vector2(horizontal * 0, rb.velocity.y);
        }


        if (Input.GetKey(KeyCode.UpArrow) && suelo)
        {
            rb.velocity = new Vector2(0.0f, impulso);
            suelo = false;
        }

        if(Input.GetKey(KeyCode.DownArrow))
        {
            player.isTrigger = true;
            if (player1.transform.localScale.y == 1f)
            {
                rb.velocity = new Vector2(0.0f, -1.0f);
                player1.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * 0.5f, transform.localScale.z);
            }
        }
        else
        {
            player.isTrigger = false;
            if (player1.transform.localScale.y < 1f)
            {
                player1.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * 2f, transform.localScale.z);
            }
        }
        if (playerdash.Isdashing)
        {

        }

    }
    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "SpawnGround")
        {
            suelo = true;
        }
        else if(collision.gameObject.tag == "Abismo"){
            Muerte();
        }
    }    
    void OnTriggerStay2D(Collider2D collision){
        if(collision.gameObject.tag == "escala" && sombra.capa){
            suelo = true;
            if(change.siLuz){
                sombra.capa = false;
            }
        }
        else if(collision.gameObject.tag == "Abismo"){
            Muerte();
        }
    }

    public void Muerte()
    {
        Life.instance.currentVidas = Life.instance.currentVidas - 1;
        if (Life.instance.currentVidas > 0)
        {
            transform.position = new Vector3(0, 0);
            rb.velocity = new Vector3(0, 0);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
