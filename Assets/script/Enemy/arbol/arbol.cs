using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arbol : MonoBehaviour
{
    public GameObject particula1;
    public GameObject particula2;

    public GameObject arbolEnemy;

    public AudioSource audio;

    Vector3 position;

    public EnemyLife life;
    // Start is called before the first frame update
    

    void SpawnParticulas(){
        audio.Play();
        position = new Vector3 (arbolEnemy.transform.position.x, arbolEnemy.transform.position.y + 10f, arbolEnemy.transform.position.z);
        GameObject particulas1 = Instantiate(particula1, position, arbolEnemy.transform.rotation);
        GameObject particulas2 = Instantiate(particula2, position, arbolEnemy.transform.rotation);
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "BOOM")
        {
            life.totalDamage = 7f;
            life.Muerte();
        }
        else if(collision.gameObject.tag == "Proyectil" || collision.gameObject.tag == "ProyectilOscuro" ){
            life.totalDamage = 1f;
            life.Muerte();
        }
        else if(collision.gameObject.tag == "AttackPlayerLuz" || collision.gameObject.tag == "AttackPlayerOscuridad")
        {
            life.totalDamage = 3f;
            life.Muerte();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "BOOM")
        {
            life.totalDamage = 7f;
            life.Muerte();
        }
        else if(collision.gameObject.tag == "Proyectil" || collision.gameObject.tag == "ProyectilOscuro" ){
            life.totalDamage = 1f;
            life.Muerte();
        }
        else if(collision.gameObject.tag == "AttackPlayerLuz" || collision.gameObject.tag == "AttackPlayerOscuridad")
        {
            life.totalDamage = 3f;
            life.Muerte();
        }
    }
}
