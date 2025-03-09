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
    public int vidas = 3;
    float currTime = 0f;
    float cooldown = 8f;
    bool changeVida;

    void Awake()
    {
        instance = this; 
    }
    private void Start()
    {
        slider.maxValue = maxVidas;
        currentVidas = maxVidas;
        vidas = currentVidas;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = currentVidas;
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
}
