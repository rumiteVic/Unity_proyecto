using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeActivo1 : MonoBehaviour
{
    // Start is called before the first frame update
    public Collider2D col;
    public GameObject objeto;
    bool once = false;
    public Animator animator;
    Pintar pinta;
    TextChanger change;
    void Start()
    {
        col.isTrigger = false;
        pinta = FindObjectOfType<Pintar>();
        change = FindObjectOfType<TextChanger>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ProyectilOscuro")
        {
            if(!once){
                col.isTrigger = true;
                animator.SetBool("destruir", true);
                pinta.SumarDestruidos();
                change.ChangeDestruidos();
                once = true;
            } 
        }
    }

    void Destruir(){
        Destroy(objeto);
    }
}
