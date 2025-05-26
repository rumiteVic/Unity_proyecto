using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class vacio : MonoBehaviour
{
    private PauseManager pause;
    // Start is called before the first frame update
    void Start()
    {
        pause = FindObjectOfType<PauseManager>();
    }

    // Update is called once per frame


    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Player"){
            pause.levoid = true;
        }

    }

    void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.tag == "Player"){
            pause.levoid = false;
        }
    }
    void OnDestroy(){
        pause.levoid = false;
    }
}
