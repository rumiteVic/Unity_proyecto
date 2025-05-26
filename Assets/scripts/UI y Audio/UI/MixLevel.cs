using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MixLevel : MonoBehaviour
{
    public AudioMixer masterMixer;

    public void SetAmbientVolume(float ambientVolume){
        masterMixer.SetFloat("AmbientVolume", ambientVolume);
    }

    public void SetMusicVolume(float musicVolume){
        masterMixer.SetFloat("MusicVolume", musicVolume);
    }

    public void SetSFXVolume(float sfxVolume){
        masterMixer.SetFloat("SFXVolume", sfxVolume);
    }
}
