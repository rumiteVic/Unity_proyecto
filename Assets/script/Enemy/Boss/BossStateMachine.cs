using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossStateMachine : MonoBehaviour
{
    // Start is called before the first frame update

    public enum bossStates {IDLE, ATTACK1, ATTACK2, DAMAGE, DEAD, MOVING };
    public bossStates currentState = bossStates.IDLE;
    public bool seeingPlayer = false;
    public GameObject player;
    public GameObject beegHitbox;
    public GameObject rock;

    private bool rockSpawned = false;
    private float playerX;
    public float bossSpeed;
    private float bossDirection;
    public float counter;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case bossStates.IDLE:
                updateIdle();
                break;

            case bossStates.MOVING:
                updateMoving();
                break;

            case bossStates.ATTACK1:
                updateAttack1();
                break;

            case bossStates.ATTACK2:
                updateAttack2();
                break;

            case bossStates.DAMAGE:
                updateDamage();
                break;

            case bossStates.DEAD:
                updateDead();
                break;

            default:break;
        }
    }

    void updateIdle()
    {
        counter = 0;
        rockSpawned = false;
        if (Mathf.Abs(this.transform.position.x - player.transform.position.x) < 10)
        {
            seeingPlayer=true;
        }

        if (seeingPlayer)
        {
            currentState = bossStates.MOVING;
        }
    }
     void updateMoving()
    {

        counter += Time.deltaTime;
        if(this.transform.position.x - player.transform.position.x > 1)
        {
            bossDirection = -1;
        }
        else
        {
            bossDirection = 1;
        }
        this.transform.position += new Vector3(bossSpeed * bossDirection, 0);

        if(counter >= 3)
        {
            counter = 0;
            if(Mathf.Abs(this.transform.position.x - player.transform.position.x) > 3)
            {
                currentState = bossStates.ATTACK1;
            }
            else
            {
                currentState = bossStates.ATTACK2;
            }

        }

    }

    void updateAttack1()
    {

        counter += Time.deltaTime;

        if (counter >= 1 && !rockSpawned)
        {
            Instantiate(rock, new Vector3(player.transform.position.x, -0.5f), transform.rotation);
            rockSpawned = true;
           
        }
        if (counter >= 2)
        {
            currentState = bossStates.IDLE;
        }


    }
    void updateAttack2()
    {
        counter += Time.deltaTime;

        if (counter >= 1 && !rockSpawned)
        {
            Instantiate(beegHitbox, new Vector3(this.gameObject.transform.position.x + (bossDirection), 0f), transform.rotation);
            rockSpawned = true;
        }
        if (counter >= 2)
        {
            currentState = bossStates.IDLE;
        }
    }
    void updateDamage()
    {

    }
    void updateDead()
    {

    }

}