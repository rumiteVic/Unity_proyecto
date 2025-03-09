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
        if(collision.gameObject.tag == "BOOM")
        {
            life.totalDamage = 7f;
            enemy.canNotMove = true;
            life.Muerte();
        }
        else if(collision.gameObject.tag == "Proyectil" || collision.gameObject.tag == "ProyectilOscuro" ){
            enemy.canNotSee = true;
            life.totalDamage = 1f;
            life.Muerte();
        }
        else if(collision.gameObject.tag == "AttackPlayerLuz" || collision.gameObject.tag == "AttackPlayerOscuridad")
        {
            life.totalDamage = 3f;
            if(collision.gameObject.tag == "AttackPlayerLuz") enemy.rebaja = true;
            life.Muerte();
        }
        else if(collision.gameObject.tag == "Escudo"){
            movimiento.ReinicioTiempo();
        }
    }
    private void OnTriggerStay2D(Collider2D collision){
        if (collision.gameObject.tag == "Muro")
        {
            life.totalDamage = 0.03f;
            enemy.muro = true;
            life.Muerte();            
        }
        else if (collision.gameObject.tag == "BOOM")
        {
            enemy.canNotMove = true;          
        }
   
    }
    private void OnTriggerExit2D(Collider2D collision){
        if(collision.CompareTag("Muro")){
            enemy.muro = false;
        }
        if(collision.CompareTag("BOOM")){
            enemy.canNotMove = false;
        }
    }
}
