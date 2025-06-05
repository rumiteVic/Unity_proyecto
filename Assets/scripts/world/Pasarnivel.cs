using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Pasarnivel : MonoBehaviour
{
    Pintar pinta;
    void Start(){
        pinta = FindObjectOfType<Pintar>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(pinta.objetosDestruidos >= pinta.destruirObjetos && pinta.objetosPintado >= pinta.pintarObjetos){
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
            }
        }

    }
}
