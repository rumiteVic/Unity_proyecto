using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Aqui controlamos el ataque y los debuffs de los enemigos :D
    public GameObject damageSensor;
    public GameObject attackSensor;
    public Movement movimiento;
    //Cooldown de hacer daño
    public bool dealDamage = false;
    float cooldown = 1f;
    float currTime = 0f;
    //Cooldown ceguera
    float cooldown2 = 1.7f;
    float currTime2 = 0f;
    public bool canNotSee = false;

    //Cooldown rebaja velocidad
    public bool rebaja;
    float currTimeVel;
    float cooldownVel = 2f;
    public bool canNotMove;
    public bool muro = false;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(dealDamage){
            currTime += Time.deltaTime;
            attackSensor.gameObject.SetActive(false);
            if(currTime >= cooldown){
                attackSensor.gameObject.SetActive(true);
                dealDamage = false;
                currTime = 0f;
            }
        }
        if(canNotSee){
            currTime2 += Time.deltaTime;
            attackSensor.gameObject.SetActive(false);
            if(currTime2 >= cooldown2){
                attackSensor.gameObject.SetActive(true);
                canNotSee = false;
                currTime2 = 0f;
            }
        }
        if (rebaja)
        {
            movimiento.speed = 0.5f;
            currTimeVel += Time.deltaTime;
            if (currTimeVel >= cooldownVel)
            {
                rebaja = false;
                currTimeVel = 0f;
            }
        }
        if(muro){
            movimiento.speed = 0.3f;
        }
        if(canNotMove){
            movimiento.speed = 0f;
        }
    }        
}
