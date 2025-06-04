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
    public GameObject particulas;
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
            GameObject instancia = Instantiate(particulas, transform.position, transform.rotation);
            Destroy(enemy, audio.clip.length);
        }
    }
}
