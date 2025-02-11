using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Habilidades_Luz : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject muroDeLuz;
    public GameObject jaula;
    public GameObject bala;
    public GameObject balaOscura;
    public float speed;
    float dirige = 2;
    float izDe;
    float horizontal;
    bool muro;
    public bool derecha;
    // Start is called before the first frame update
    void Start()
    {
        derecha = true;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        if (horizontal < 0)
        {
            derecha = false;
        }
        else if(horizontal > 0)
        {
            derecha = true;
        }

        if(derecha){
            izDe =1f;
        }
        if(!derecha){
            izDe = -1f;
        }
        //El muro
        if (Input.GetKeyDown(KeyCode.S))
        {
            muro = true;
                
        }
        if (muro)
        {
            Vector2 direccion = new Vector2(transform.position.x + dirige * izDe, transform.position.y + 1.5f);
            GameObject tempMuro = Instantiate(muroDeLuz, direccion, transform.rotation);
            muro = false;
            Destroy(tempMuro, 7);
        }

        //Jaula
        if (Input.GetKeyDown(KeyCode.Q))
        {
            muro = true;

        }
        if (muro)
        {
            Vector2 direccion = new Vector2(transform.position.x + dirige * izDe, transform.position.y);
            GameObject tempMuro = Instantiate(jaula, direccion, transform.rotation);
            muro = false;
            Destroy(tempMuro, 7);
        }
        //Bala normal
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject objeto = Instantiate(bala, transform.position, transform.rotation);
            rb = GetComponent<Rigidbody2D>();

            rb.velocity = new Vector2(izDe * speed, rb.velocity.y);
            Destroy(objeto, 2);
        }
        //Bala oscura
        if (Input.GetKeyDown(KeyCode.V))
        {
            GameObject objetoOscuro = Instantiate(balaOscura, transform.position, transform.rotation);
           
            rb = GetComponent<Rigidbody2D>();

            rb.velocity = new Vector2(izDe * speed, rb.velocity.y);
            Destroy(objetoOscuro, 2);
        }
    }


}
