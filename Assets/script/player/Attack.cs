using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Transform attackAreaLuz;
    public Transform attackAreaOscuridad;
    public ChangeLight change;
    private float cooldown = 0.25f;
    float currTime = 0f;
    bool isAttack = false;
    float horizontal;
    private float cooldownattack = 0.8f;
    bool isAttacking = false;
    float currAtt = 0f;

    public Animator animatorLuz;
    public Animator animatorOsc;

    // Start is called before the first frame update
    void Start()
    {
        attackAreaLuz.gameObject.SetActive(false);
        attackAreaOscuridad.gameObject.SetActive(false);

    }
    void Update()
    {
        attack();
    }

    void attack()
    {
        
        if (Input.GetKeyDown(KeyCode.X) && currAtt == 0)
        {
            isAttack = true;
            if(change.siLuz)attackAreaLuz.gameObject.SetActive(true);
            else attackAreaOscuridad.gameObject.SetActive(true);
            isAttacking = true;
            animatorOsc.SetTrigger("attack");
            animatorLuz.SetTrigger("attack");
            
        }
        if (isAttack)
        {
            currTime += Time.deltaTime;

            if (currTime >= cooldown)
            {
                if(change.siLuz)attackAreaLuz.gameObject.SetActive(false);
                else attackAreaOscuridad.gameObject.SetActive(false);
                isAttack = false;
                currTime = 0f;
            }
        }
        if(isAttacking){
             currAtt +=Time.deltaTime;
             if(currAtt >= cooldownattack){
                isAttacking = false;
                currAtt = 0f;
             }
        }
    }
}

