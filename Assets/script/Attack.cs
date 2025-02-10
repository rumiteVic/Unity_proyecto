using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Attack : MonoBehaviour
{

    public Transform attackArea;
    private float cooldown = 0.5f;
    float currTime = 0f;
    bool isAttack = false;
    float horizontal;

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
        
        if (Input.GetKeyDown(KeyCode.X))
        {
            isAttack = true;
            attackArea.gameObject.SetActive(true);
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
    }
}
