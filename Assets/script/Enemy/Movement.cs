using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    public float speed;
    public Transform enemigo;
    public Rigidbody2D rb;
    public GameObject destination1;
    public GameObject destination2;
    private Transform currentDestination;
    public Movimiento player;
    public Enemy enemy;
    Vector2 direction;
    float cooldown = 5;
    float x;
    float y;
    float currTime = 0;
    public bool empujado;
    float currTime1 = 0f;
    float cooldown2 = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        currentDestination = destination1.transform;
        rb = GetComponent<Rigidbody2D>();
        direction = (currentDestination.position - transform.position).normalized;
        x = enemigo.position.x;
        y = enemigo.position.y;
    }
    
    // Update is called once per frame
    void Update()
    {        
        if(!enemy.rebaja && !enemy.muro &&!enemy.canNotMove)speed = 5;
        rb.velocity = direction*speed;
        currTime += Time.deltaTime;
        if(currTime >= cooldown){
            x = enemigo.position.x;
            y = enemigo.position.y;
            currTime = 0;
        }
        Vector2 direccion = new Vector2 (player.izde * 500f, 0);
        if(empujado){
             rb.AddForce(direccion);
             currTime1 += Time.deltaTime;
             if(currTime1 >= cooldown2){
                currTime1 = 0f;
                empujado = false;
             }
        }
       
        ChangeDirection();
    }

    void ChangeDirection()
    {
        if (Vector2.Distance(transform.position, currentDestination.position) < 1.5f && currentDestination.position == destination1.transform.position)
        {
            currentDestination = destination2.transform;
            direction = (currentDestination.position - transform.position).normalized;
        }
        else if(Vector2.Distance(transform.position, currentDestination.position) < 1.5f && currentDestination.position == destination2.transform.position)
        {
            currentDestination = destination1.transform;
            direction = (currentDestination.position - transform.position).normalized;
        }
    }

    public void ReinicioTiempo(){
        transform.position = new Vector3(x, y);
    }
}
