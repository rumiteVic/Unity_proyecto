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
    void Start()
    {
        col.isTrigger = true;
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
                notOtraVez = false;
            }
            
        }
    }
}