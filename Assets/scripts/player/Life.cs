using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    public static Life instance; 

    public int maxVidas = 3;
    public int currentVidas;

    HUD hud;
    public AudioSource audio;
    public GameObject zenith;
    public Movimiento mov;

    void Awake()
    {
        instance = this; 
    }
    private void Start()
    {
        hud = FindObjectOfType<HUD>();
        currentVidas = maxVidas;
    }

    public void Muerte(){
        audio.Play();
        currentVidas--;
        if (hud.vidas[currentVidas] != null) hud.vidas[currentVidas].enabled = false;
        if (hud.sinVidas[currentVidas] != null) hud.sinVidas[currentVidas].enabled = true;
    }
}