using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPasos : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip pasos;
    public AudioClip jump;

    public AudioSource audioAttack;
    public AudioClip attack;
    public AudioClip launch;

    public float minPitch;
    public float maxPitch;

    public float volumeMin;
    public float volumeMax;
    
    public Movimiento mov;

    void PlayPasos(){
        audio.clip= pasos;
        if(mov.suelo)audio.Play();
        ChangeNext();
    }

    void PlayJump(){
        audio.clip= jump;
        audio.Play();
        ChangeNext();
    }

    void PlayAttack(){ 
        audioAttack.clip = attack;
        audioAttack.Play();
        ChangeNext();
    }

    void PlayLaunch(){
        audioAttack.clip = launch;
        audioAttack.Play();
        ChangeNext();
    }

    void ChangeNext(){
        audio.pitch = 1.0f + Random.Range(minPitch, maxPitch);
        audio.volume = 1.0f + Random.Range(volumeMin, volumeMax);  
    }
}
