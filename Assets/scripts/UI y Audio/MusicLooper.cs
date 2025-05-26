using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLooper : MonoBehaviour {
    private AudioSource audioSource;

    public float loopStartTime;
    public float loopEndTime;
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (audioSource != null &&
            audioSource.isPlaying && 
            audioSource.time > loopEndTime)
        {
            audioSource.time = loopStartTime;
        }
	}

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Player"){
            audioSource.Play();
        }
    }

    void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.tag == "Player"){
            audioSource.Stop();
        }
    }
}
