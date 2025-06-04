using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecieveDamageEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public Collider2D enemycoll;
    public EnemyLife life;
    public Enemy enemy;
    public Movement movimiento;
    float currTime = 0f;
    float cooldown = 0.4f;
    public bool recibe = false;

    public GameObject one;
    public GameObject three;
    Vector2 where;
    void Start()
    {
        enemycoll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
         if(recibe){
            life.totalDamage = 2f;
            recibe = false;
            life.Muerte();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        where = new Vector2 (transform.position.x, transform.position.y +2f);
        if(collision.gameObject.tag == "Proyectil" || collision.gameObject.tag == "ProyectilOscuro" ){
            life.totalDamage = 1f;
            GameObject instancia = Instantiate(one, where, transform.rotation);
            life.Muerte();
        }
        else if(collision.gameObject.tag == "AttackPlayerLuz" || collision.gameObject.tag == "AttackPlayerOscuridad")
        {
            life.totalDamage = 3f;
            if(collision.gameObject.tag == "AttackPlayerLuz") enemy.rebaja = true;
            if(collision.gameObject.tag == "AttackPlayerOscuridad") movimiento.empujado = true;
            GameObject instancia = Instantiate(three, where, transform.rotation);
            life.Muerte();
        }
        else if (collision.gameObject.tag == "Ground"){
            movimiento.normal = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision){
        if (collision.gameObject.tag == "BOOM")
        {
            enemy.canNotMove = true;          
        }
        else if(collision.gameObject.tag == "BOOMOSC"){
            movimiento.normal = true;
            currTime += Time.deltaTime;
            if(currTime >= cooldown){
                life.totalDamage = 0.3f;
                currTime = 0f;
                life.Muerte();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision){
        if(collision.CompareTag("BOOM")){
            enemy.canNotMove = false;
        }
        if(collision.CompareTag("BOOMOSC")){
            currTime = 0f;
        }
    }
}
