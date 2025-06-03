using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyLife : MonoBehaviour
{
    public float maxVidas = 20;
    public float currentVidas;
    public GameObject enemy;
    public float totalDamage;
    public Slider slideLife;

    public AudioSource audio;

    void Awake()
    {
        
    }
    private void Start()
    {
        currentVidas = maxVidas;
        slideLife.maxValue = maxVidas;
        slideLife.value = maxVidas;
    }

    // Update is called once per frame
    void Update()
    {
        slideLife.value = currentVidas;
    }
    public void Muerte()
    {
        audio.Play();
        currentVidas = currentVidas - totalDamage;
        if (currentVidas <= 0)
        {
            Destroy(enemy, audio.clip.length);
        }
    }
}
