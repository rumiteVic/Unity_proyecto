using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    public static Life instance; 

    public int maxVidas = 3;
    public int currentVidas;
    public int vidas = 3;
    float currTime = 0f;
    float cooldown = 8f;
    bool changeVida;
    HUD hud;
    public AudioSource audio;
    public GameObject zenith;

    void Awake()
    {
        instance = this; 
    }
    private void Start()
    {
        hud = FindObjectOfType<HUD>();
        currentVidas = maxVidas;
        vidas = currentVidas;
    }

    // Update is called once per frame
    void Update()
    {
        if(changeVida){
            currentVidas = vidas;
            changeVida = false;
        }
        currTime += Time.deltaTime;
        if(currTime >= cooldown){
            vidas = currentVidas;
            currTime = 0;
        }
    }
    public void RecuperarVida(){
        changeVida = true;
    }

    public void Muerte(){
        audio.Play();
        currentVidas--;
        if (hud.vidas[currentVidas] != null) hud.vidas[currentVidas].enabled = false;
        if (hud.sinVidas[currentVidas] != null) hud.sinVidas[currentVidas].enabled = true;
        if(currentVidas <= 0){
            Destroy(zenith, audio.clip.length);
        }
    }
}