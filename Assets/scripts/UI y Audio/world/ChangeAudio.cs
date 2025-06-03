using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAudio : MonoBehaviour
{
    public AudioSource audio;
    [SerializeField]public AudioClip music;
    [SerializeField]public AudioClip musicEnemy;

    public Collider2D coll;

    public void Music(){
        audio.clip = music;
        audio.Play();
        coll.GetComponent<Collider2D>();
    }

    public void MusicEnemy(){
        audio.clip = musicEnemy;
        audio.Play();
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Player")MusicEnemy();
    }

    void OnCollisionExit2D(Collision2D collision){
        if(collision.gameObject.tag == "Player") Music();
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Player")MusicEnemy();
    }

    void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.tag == "Player") Music();
    }

}
