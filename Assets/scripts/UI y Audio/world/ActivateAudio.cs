using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAudio : MonoBehaviour
{
    public AudioSource audio;
    public float loopStartTime;
    public float loopEndTime;
	// Use this for initialization
	// Update is called once per frame
	void Update () {
        if (audio != null &&
            audio.isPlaying && 
            audio.time > loopEndTime)
        {
            audio.time = loopStartTime;
        }
	}
    void OnTriggerEnter2D(Collider2D collision){
        audio.Play();
    }

    void OnTriggerExit2D(Collider2D collision){
        audio.Stop();
    }
}
