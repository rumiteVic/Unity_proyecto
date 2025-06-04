using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arbolDamage : MonoBehaviour
{
    Life player;
    // Start is called before the first frame update
    void Start()
    {
        player= FindObjectOfType<Life>();
    }

    // Update is called once per frame
    void OnParticleCollision(GameObject objeto){
        if(objeto.tag == "Player") {
            player.Muerte();
        }
    }
}
