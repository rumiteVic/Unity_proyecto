using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NoMovement : MonoBehaviour
{
    public Movement enemy;
    public bool noMovement;
    float currTime;
    float cooldown = 7f;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (noMovement)
        {
            currTime += Time.deltaTime;
            if (currTime >= cooldown)
            {
                enemy.enabled = true;
                noMovement = false;
                currTime = 0f;
                enemy.enabled = !enemy.enabled;
            }
        }
        else
        {
            enemy.enabled = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Jaula" && !noMovement)
        {
            noMovement = true;
            enemy.enabled = false;
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "BOOMOSC"){
            noMovement = true;
            enemy.enabled = false;
        }

    }

}
