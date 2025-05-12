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
        isGrounded = true;
        rb.velocity = Vector3.zero;
        if (collision.gameObject.tag == "BOOM" || collision.gameObject.tag == "BOOMOSC" || collision.gameObject.tag == "Proyectil" || collision.gameObject.tag == "ProyectilOscuro" || collision.gameObject.tag == "Muro" || collision.gameObject.tag == "Jaula" || collision.gameObject.tag == "Abismo" || collision.gameObject.tag == "AttackPlayerLuz" || collision.gameObject.tag == "AttackPlayerOscuridad" || collision.gameObject.tag == "Gravitacional")
        {
            life.currentVidas--;
            if (life.currentVidas <= 0)
            {
                life.Muerte();
            }
        }
    }
}