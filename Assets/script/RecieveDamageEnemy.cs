using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecieveDamageEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    public Collider2D enemycoll;
    public EnemyLife life;
    float totalDamage;
    void Start()
    {
        enemycoll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "BOOM" || collision.gameObject.tag == "BOOMOSC")
        {
            totalDamage = 7f;
            Muerte();
        }
        else if(collision.gameObject.tag == "Proyectil" || collision.gameObject.tag == "ProyectilOscuro" ){
            totalDamage = 1f;
            Muerte();
        }
        else if(collision.gameObject.tag == "AttackPlayer")
        {
            totalDamage = 3f;
            Muerte();
        }
    }
    void OnTriggerStay2D(Collider2D collision){


        if (collision.gameObject.tag == "Muro")
        {
            totalDamage = 0.03f;
            Muerte();            
        }
   
    }
    public void Muerte()
    {
        life.currentVidas = life.currentVidas - totalDamage;
        if (life.currentVidas < 0)
        {
            Destroy(enemy);
        }
    }

}
