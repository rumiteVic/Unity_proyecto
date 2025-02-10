using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    public static Life instance; 

    public int maxVidas = 3;
    public int currentVidas;

    public Slider slider;

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
