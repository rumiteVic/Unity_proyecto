using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliminarVacio : MonoBehaviour
{
    public Animator animator;
    bool notOtraVez = true;
    Pintar pinta;
    TextChanger change;
    void Start()
    {
        pinta = FindObjectOfType<Pintar>();
        change = FindObjectOfType<TextChanger>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Proyectil")
        {
            if(notOtraVez){
                animator.SetBool("change", true);
                pinta.SumarPintados();
                change.ChangePintados();
                notOtraVez = false;
            }
            
        }
    }

    public void NoVacio(){
        Destroy(gameObject);
    }

}
