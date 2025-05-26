using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pasos : MonoBehaviour
{
    //Audio
    public AudioSource footsteps;

    public float minPitch;
    public float maxPitch;

    public float volumeMin;
    public float volumeMax;
    // Start is called before the first frame update

    public void Pasos()
    {
        footsteps.pitch = 1.0f + Random.Range(minPitch, maxPitch);
        footsteps.volume = 1.0f + Random.Range(volumeMin, volumeMax);    
        footsteps.Play();
    }
}
