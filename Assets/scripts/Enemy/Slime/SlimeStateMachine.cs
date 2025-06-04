using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SlimeStateMachine : MonoBehaviour
{
    // Start is called before the first frame update

    public enum slimeStates { IDLE, MOVING };
    public slimeStates currentState = slimeStates.IDLE;
    Rigidbody2D rb;
    public Collider2D ground;
    private float counter;
    public bool isGrounded;
    public float force;
    public Animator slime;
    public EnemyLife life;

    public GameObject one;
    public GameObject three;
    Vector2 where;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case slimeStates.IDLE:
                updateIdle();
                break;

            case slimeStates.MOVING:
                updateMoving();
                break;

            default: break;
        }
    }

    void updateIdle()
    {

        counter += Time.deltaTime;
        slime.SetBool("isIdle", true);
        if (counter >= 3f)
        {
            counter = 0;
            currentState = slimeStates.MOVING;
        }
    }
    void updateMoving()
    {
        slime.SetBool("isIdle", false);
        slime.SetTrigger("jump");
        if (isGrounded)
        {
            slime.SetBool("isIdle", true);
            isGrounded = false;
            rb.velocity = new Vector3(force * -1, force, 0);
            currentState = slimeStates.IDLE;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        where = new Vector2 (transform.position.x, transform.position.y +2f);
        isGrounded = true;
        rb.velocity = Vector3.zero;
        if (collision.gameObject.tag == "Proyectil" || collision.gameObject.tag == "ProyectilOscuro")
        {
            GameObject instancia = Instantiate(one, where, transform.rotation);
            life.currentVidas--;
            if (life.currentVidas <= 0)
            {
                life.Muerte();
            }
        }
        if(collision.gameObject.tag == "AttackPlayerLuz" || collision.gameObject.tag == "AttackPlayerOscuridad"){
            life.currentVidas -= 3;
            GameObject instancia = Instantiate(three, where, transform.rotation);
            if (life.currentVidas <= 0)
            {
                life.Muerte();
            }
        }
        if(collision.gameObject.tag == "Abismo" ){
            life.currentVidas = -1;
            if (life.currentVidas <= 0)
            {
                life.Muerte();
            }
        }
    }
}