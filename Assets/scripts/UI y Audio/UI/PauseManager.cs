using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PauseManager : MonoBehaviour
{
    public Slider musicVolumeSlider;
    public Slider ambientVolumeSlider;
    public Slider sfxVolumeSlider;

    public AudioMixerSnapshot paused;
    public AudioMixerSnapshot unpaused;
    public AudioMixerSnapshot elVacio;
    public AudioMixerSnapshot light;

    public UI ui;
    public bool levoid = false;
    public bool lighty = false;
    // Start is called before the first frame update
    void Start()
    {
        musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0f);
        ambientVolumeSlider.value = PlayerPrefs.GetFloat("AmbientVolume", 0f);
        sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(ui.menu == 1){
            paused.TransitionTo(0.01f);
        }
        else if(levoid){
            elVacio.TransitionTo(0.01f);
        }
        else if(lighty){
            light.TransitionTo(0.01f);
        }
        else if(ui.menu != 1 || !levoid || !lighty){
            unpaused.TransitionTo(0.01f);
        }
    }
}
