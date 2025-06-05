using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeActivo : MonoBehaviour
{
    // Start is called before the first frame update
    public Collider2D col;
    public GameObject suelo;

    public Animator animator;
    bool notOtraVez = true;
    Pintar pinta;
    TextChanger change;
    void Start()
    {
        col.isTrigger = true;
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
                col.isTrigger = false;
                animator.SetBool("change", true);
                pinta.SumarPintados();
                change.ChangePintados();
                notOtraVez = false;
            }
            
        }
    }
}