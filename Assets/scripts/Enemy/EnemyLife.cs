using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public float maxVidas = 20;
    public float currentVidas;
    public GameObject enemy;
    public float totalDamage;

    public AudioSource audio;

    void Awake()
    {
        
    }
    private void Start()
    {
        currentVidas = maxVidas;
    }

    // Update is called once per frame
    void Update()
    {
        
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
