using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
[Header("Referencias")]
    public Transform enemigo;
    public GameObject destination1;
    public GameObject destination2;
    public Movimiento player;
    public Enemy enemy;
    public RecieveDamageEnemy recibe;

    [Header("Movimiento")]
    public float speed = 5f;
    private Transform currentDestination;
    private Rigidbody2D rb;
    private Vector2 direction;

    [Header("Estados")]
    public bool empujado;
    public bool vuela;
    public bool normal;

    // Tiempos y cooldowns
    private float currTimeEmpuje;
    private float currTimeVuelo;

    private float cooldownEmpuje = 0.3f;
    private float cooldownVuelo = 0.1f;
    float direccionLanzar = 1;
    
    public SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<Movimiento>();

        currentDestination = destination1.transform;
        direction = (currentDestination.position - transform.position).normalized;
    }

    void Update()
    {
        if(player.srLuz.flipX || player.srOsc.flipX){
            direccionLanzar = 1f;
        }
        else if(!player.srLuz.flipX || !player.srOsc.flipX){
            direccionLanzar = -1f;
        }
        if (!enemy.rebaja && !enemy.canNotMove && !vuela)
            speed = 5f;

        rb.velocity = direction * speed;
        HandleEmpuje();
        HandleNormal();

        ChangeDirection();
    }

    void HandleEmpuje()
    {
        if (!empujado) return;

        Vector2 fuerza = new Vector2(direccionLanzar * 50f, 0);
        rb.AddForce(fuerza);

        currTimeEmpuje += Time.deltaTime;
        if (currTimeEmpuje >= cooldownEmpuje)
        {
            currTimeEmpuje = 0f;
            empujado = false;
        }
    }


    void HandleNormal()
    {
        if (normal)
        {
            rb.gravityScale = 1f;
            normal = false;
        }
    }

    void ChangeDirection()
    {
        if (Vector2.Distance(transform.position, currentDestination.position) < 1.5f)
        {
            if (currentDestination == destination1.transform)
            {
                currentDestination = destination2.transform;
                sr.flipX = false;
            }
            else
            {
                currentDestination = destination1.transform;
                sr.flipX = true;
            }

            direction = (currentDestination.position - transform.position).normalized;
        }
    }

}
