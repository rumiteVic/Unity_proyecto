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
    public Animator anim;
    public EnemyLife life;

    private BossDeath death;
    private bool rockSpawned = false;
    private float playerX;
    public float bossSpeed;
    private float bossDirection;
    public float counter;
    void Start()
    {
        death = GetComponent<BossDeath>();
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
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
        //animatorOsc.SetTrigger("jump");
        //animatorLuz.SetTrigger("jump");
        //animatorLuz.SetBool("isRunning", false);
        anim.SetBool("caminar", true);

        counter += Time.deltaTime;
        if(this.transform.position.x - player.transform.position.x > 1)
        {
            bossDirection = -1;
            GetComponent<SpriteRenderer>().flipX = true;
            GetComponent<BoxCollider2D>().offset = new Vector2(0.5f, -0.6f);
        }
        else
        {
            bossDirection = 1;
            GetComponent<SpriteRenderer>().flipX = false;
            GetComponent<BoxCollider2D>().offset = new Vector2(-0.5f, -0.6f);
        }
        this.transform.position += new Vector3(bossSpeed * bossDirection, 0);

        if(counter >= 3 || Mathf.Abs(this.transform.position.x - player.transform.position.x) < 1)
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
        anim.SetBool("caminar", false);
        anim.SetTrigger("pisada");
        counter += Time.deltaTime;

        if (counter >= 1 && !rockSpawned)
        {
            Instantiate(rock, new Vector3(player.transform.position.x, this.gameObject.transform.position.y -1.5f), transform.rotation);
            rockSpawned = true;
           
        }
        if (counter >= 2)
        {
            currentState = bossStates.IDLE;
        }
    }
    void updateAttack2()
    {
        anim.SetBool("caminar", false);
        anim.SetTrigger("ataque");
        counter += Time.deltaTime;

        if (counter >= 1 && !rockSpawned)
        {
            Instantiate(beegHitbox, new Vector3(this.gameObject.transform.position.x + (bossDirection), this.gameObject.transform.position.y), transform.rotation);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BOOM" || collision.gameObject.tag == "BOOMOSC" || collision.gameObject.tag == "Proyectil" || collision.gameObject.tag == "ProyectilOscuro" || collision.gameObject.tag == "Muro" || collision.gameObject.tag == "Jaula" || collision.gameObject.tag == "Abismo" || collision.gameObject.tag == "AttackPlayerLuz" || collision.gameObject.tag == "AttackPlayerOscuridad" || collision.gameObject.tag == "Gravitacional")
        {
            life.currentVidas--;
            if (life.currentVidas <= 0)
            {
                life.Muerte();
                death.Win();
            }
        }
    }
}