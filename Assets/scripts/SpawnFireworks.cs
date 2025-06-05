using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFireworks : MonoBehaviour
{
    Pintar pinta;
    public GameObject firework;
    // Start is called before the first frame update
    void Start()
    {
        pinta = FindObjectOfType<Pintar>();
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Player" && pinta.objetosPintado >=  pinta.pintarObjetos && pinta.objetosDestruidos >= pinta.destruirObjetos){
            GameObject fire1 = Instantiate(firework, transform.position, transform.rotation);
            GameObject fire2 = Instantiate(firework, transform.position, transform.rotation);
        }
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Player" && pinta.objetosPintado >=  pinta.pintarObjetos && pinta.objetosDestruidos >= pinta.destruirObjetos){
            GameObject fire1 = Instantiate(firework, transform.position, transform.rotation);
            GameObject fire2 = Instantiate(firework, transform.position, transform.rotation);
        }
    }
}
