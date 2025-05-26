using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light : MonoBehaviour
{
    private PauseManager pause;
    // Start is called before the first frame update
    void Start()
    {
        pause = FindObjectOfType<PauseManager>();
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Player"){
            pause.lighty = true;
        }

    }

    void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.tag == "Player"){
            pause.lighty = false;
        }
    }
    void OnDestroy(){
        pause.lighty = false;
    }

}
