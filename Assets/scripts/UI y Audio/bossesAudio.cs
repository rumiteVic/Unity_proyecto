using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossesAudio : MonoBehaviour
{
    public AudioSource audio;

    public AudioClip attack1;
    public AudioClip attack2;
    public AudioClip attack3;
    public AudioClip attack4;

    public float minPitch;
    public float maxPitch;

    public float volumeMin;
    public float volumeMax;

    void Attack1Play(){
        audio.clip = attack1;
        audio.Play();
        ChangeNext();
    }
    void Attack2Play(){
        audio.clip = attack2;
        audio.Play();
        ChangeNext();
    }
    void Attack3Play(){
        audio.clip = attack3;
        audio.Play();
        ChangeNext();
    }
    void Attack4Play(){
        audio.clip = attack4;
        audio.Play();
        ChangeNext();
    }

    void ChangeNext(){
        audio.pitch = 1.0f + Random.Range(minPitch, maxPitch);
        audio.volume = 1.0f + Random.Range(volumeMin, volumeMax);  
    }

}
