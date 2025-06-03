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

    // Update is called once per frame
    void Update()
    {

    }

    public void Muerte(){
        audio.Play();
        currentVidas--;
        if (hud.vidas[currentVidas] != null) hud.vidas[currentVidas].enabled = false;
        if (hud.sinVidas[currentVidas] != null) hud.sinVidas[currentVidas].enabled = true;
        if(currentVidas <= 0){
            zenith.transform.position = mov.spawnPlace;
            currentVidas = maxVidas;
            for (int i = 0; i < maxVidas; i++)
            {
                if (hud.vidas[i] != null) hud.vidas[i].enabled = true;
                if (hud.sinVidas[i] != null) hud.sinVidas[i].enabled = false;
            }
        }
    }
}