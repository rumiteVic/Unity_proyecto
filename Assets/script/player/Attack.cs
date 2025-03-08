using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    public Transform attackArea;
    private float cooldown = 0.25f;
    float currTime = 0f;
    bool isAttack = false;
    float horizontal;
    private float cooldownattack = 0.8f;
    bool isAttacking = false;
    float currAtt = 0f;

    // Start is called before the first frame update
    void Start()
    {
        attackArea.gameObject.SetActive(false);

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
            attackArea.gameObject.SetActive(true);
            isAttacking = true;
        }
        if (isAttack)
        {
            currTime += Time.deltaTime;

            if (currTime >= cooldown)
            {
                Debug.Log("what");
                attackArea.gameObject.SetActive(false);
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

