using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeActivo : MonoBehaviour
{
    // Start is called before the first frame update
    public Collider2D col;
    public GameObject suelo;
    void Start()
    {
        col.isTrigger = true;
        suelo.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Proyectil")
        {
            col.isTrigger = false;
            suelo.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 100f);
        }
        if (collision.tag == "ProyectilOscuro")
        {
            col.isTrigger = true;
            suelo.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 0.5f);
        }
    }
}
