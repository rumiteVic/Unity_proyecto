using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BossDead : MonoBehaviour
{
    Pintar pinta;
    public bool bossDead = false;
    void Start(){
        pinta = FindObjectOfType<Pintar>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(pinta.objetosDestruidos >= pinta.destruirObjetos && pinta.objetosPintado >= pinta.pintarObjetos &&bossDead){
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
            }
        }

    }
}
