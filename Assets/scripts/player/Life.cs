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

    public GameObject particulasDamage;
    public GameObject one;
    Vector2 where;

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
        where = new Vector2(transform.position.x, transform.position.y +2f);
        GameObject instancia = Instantiate(particulasDamage, transform.position, transform.rotation);
        GameObject instancia1 = Instantiate(one, where, transform.rotation);
        if (hud.vidas[currentVidas] != null) hud.vidas[currentVidas].enabled = false;
        if (hud.sinVidas[currentVidas] != null) hud.sinVidas[currentVidas].enabled = true;
    }
}