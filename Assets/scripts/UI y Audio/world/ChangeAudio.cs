using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAudio : MonoBehaviour
{
    public AudioSource audio;
    [SerializeField]public AudioClip music;
    [SerializeField]public AudioClip musicEnemy;

    public void Music(){
        audio.clip = music;
        audio.Play();
    }

    public void MusicEnemy(){
        audio.clip = musicEnemy;
        audio.Play();
    }

    void OnTriggerEnter2D(Collider2D collision){
        MusicEnemy();
    }

    void OnTriggerExit2D(Collider2D collision){
        Music();
    }

}
