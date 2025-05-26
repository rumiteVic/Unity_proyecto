using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAudioController : MonoBehaviour
{

    public AudioSource audioSource;
    public float minPitch;
    public float maxPitch;

    public float volumeMin;
    public float volumeMax;

    private void Awake()
    {
        audioSource= GetComponent<AudioSource>();
        audioSource.pitch = 1.0f + Random.Range(minPitch, maxPitch);
        audioSource.volume = 1.0f + Random.Range(volumeMin, volumeMax);      
    }
}
