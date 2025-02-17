using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public float maxVidas = 20;
    public float currentVidas;

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
}
