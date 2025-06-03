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
    void Start()
    {
        col.isTrigger = false;
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
                once = true;
                col.isTrigger = true;
                animator.SetBool("destruir", true);
            } 
        }
    }

    void Destruir(){
        Destroy(objeto);
    }
}
