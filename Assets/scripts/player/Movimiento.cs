using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public Life life;
    public float horizontal;
    public float izde;
    float vertical;
    public float speed;
    public float impulso;
    public bool suelo;
    public bool jump = false;
    public Rigidbody2D rb;
    public Collider2D player;
    public HabilidadesSombra sombra;
    public ChangeLight change;
    public GameObject player1;
    public Dash dash;

    bool agachar;
    bool agaching;

    float currTim = 0f;
    float cooldown = 0.5f;

    float currTim1 = 0f;
    float cooldown1 = 0.8f;
    //Animation haha
    public Animator animatorLuz;
    public Animator animatorOsc;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<Collider2D>();
        player.isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        if (horizontal > 0){
            if(!dash.isdashing) rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
            transform.localRotation = Quaternion.Euler(0,0,0);
            izde = 1f;
            if(suelo)
            {
                animatorLuz.SetBool("isRunning", true);
                animatorOsc.SetBool("isRunning", true);
            }
        }
        if (horizontal < 0)
        {
            if(!dash.isdashing)rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
            transform.localRotation = Quaternion.Euler(0,180,0);
            izde = -1f;
            if(suelo)
            {
                animatorLuz.SetBool("isRunning", true);
                animatorOsc.SetBool("isRunning", true);
            }
        }
        if (horizontal == 0)
        {
            if(!dash.isdashing)rb.velocity = new Vector2(horizontal * 0, rb.velocity.y);
            if(suelo)
            {
                animatorLuz.SetBool("isRunning", false);
                animatorOsc.SetBool("isRunning", false);
            }
        }


        if (Input.GetKey(KeyCode.UpArrow) && suelo && currTim == 0f)
        {
            rb.velocity = new Vector2(0.0f, impulso);
            jump = true;
            suelo = false;
            animatorOsc.SetTrigger("jump");
            animatorLuz.SetTrigger("jump");
        }
        if(jump){
            currTim += Time.deltaTime;
            if(currTim >= cooldown){
                currTim = 0f;
                jump = false;
            }
        }

        if(Input.GetKey(KeyCode.DownArrow) && agachar)
        {
            agaching = true;
            agachar = false;
            if (player1.transform.localScale.y == 1f)
            {
                rb.velocity = new Vector2(0.0f, -1.0f);
                player1.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * 0.5f, transform.localScale.z);
            }
        }
        if(agaching){
            currTim1 += Time.deltaTime;
            if(currTim1 >= cooldown1){
                currTim1 = 0f;
                agaching = false;
                player.isTrigger = false;
                if (player1.transform.localScale.y < 1f)
                {
                    player1.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * 2f, transform.localScale.z);
                }
            }
        }

        if (sombra.capa)
        {
            if(rb.velocity.y < -3)
            {
                rb.velocity = new Vector3(rb.velocity.x, -3, 0);
            }
        }
        else if(!sombra.capa)
        {
            rb.gravityScale = 1f;
        }

    }
    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "SpawnGround")
        {
            suelo = true;
            agachar = true;
        }
        else if(collision.gameObject.tag == "Abismo"){
            Vector2 direc = new Vector2 (-4, -1);
            transform.position = direc;
            Muerte();
            life.Muerte();
        }
    }    
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Abismo"){
            Vector2 direc = new Vector2 (-4, -1);
            transform.position = direc;
            Muerte();
            life.Muerte();
        }
    }
    void OnCollisionExit2D(Collision2D collision){
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "SpawnGround")
        {
            suelo = false;
            agachar = false;
        }
    }
    void OnCollisionStay2D(Collision2D collision){
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "SpawnGround")
        {
            suelo = true;
            agachar = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("BOOM"))
        {
            speed = 6f;
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BOOM")
        {
            speed = 9f;
        }
    }
    void Muerte()
    {
        animatorOsc.SetTrigger("recieveDamage");
        animatorLuz.SetTrigger("recieveDamage");
    }

}
