using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public static EnemyLife instance; 

    public float maxVidas = 20;
    public float currentVidas;

    void Awake()
    {

        instance = this; 
        
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
