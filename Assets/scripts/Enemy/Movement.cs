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

    private float x, y;

    // Tiempos y cooldowns
    private float currTimeEmpuje;
    private float currTimeVuelo;

    private float cooldownEmpuje = 0.3f;
    private float cooldownVuelo = 0.1f;
    float direccionLanzar = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<Movimiento>();

        currentDestination = destination1.transform;
        direction = (currentDestination.position - transform.position).normalized;

        x = enemigo.position.x;
        y = enemigo.position.y;
    }

    void Update()
    {
        if(player.srLuz.flipX || player.srOsc.flipX){
            direccionLanzar = 1f;
        }
        else if(!player.srLuz.flipX || !player.srOsc.flipX){
            direccionLanzar = -1f;
        }
        if (!enemy.rebaja && !enemy.muro && !enemy.canNotMove && !vuela)
            speed = 5f;

        rb.velocity = direction * speed;


        HandleEmpuje();
        HandleVuelo();
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

    void HandleVuelo()
    {
        if (!vuela) return;

        rb.gravityScale = -700;
        speed = 0f;

        currTimeVuelo += Time.deltaTime;
        if (currTimeVuelo >= cooldownVuelo)
        {
            rb.gravityScale = 300;
            currTimeVuelo = 0f;
            vuela = false;
            recibe.recibe = true;
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
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                currentDestination = destination1.transform;
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }

            direction = (currentDestination.position - transform.position).normalized;
        }
    }

    public void ReinicioTiempo()
    {
        transform.position = new Vector3(x, y);
    }
}
