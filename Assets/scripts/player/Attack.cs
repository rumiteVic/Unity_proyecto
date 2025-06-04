using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Transform attackArea;
    public bool attacking;
    float timeAtt = 0.35f;
    float cooldown = 1f;
    float currentTime = 0;

    public GameObject player;
    public Movimiento mov;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        attackArea.gameObject.SetActive(false);
    }
    void Update()
    {
        if(mov.srLuz.flipX || mov.srOsc.flipX){
            attackArea.transform.position = new Vector2(player.transform.position.x -1.9f, player.transform.position.y);
        }
        else if(!mov.srLuz.flipX || !mov.srOsc.flipX){
            attackArea.transform.position = new Vector2(player.transform.position.x + 2f, player.transform.position.y);
        }
        Ataque();
    }

    public void Ataque(){        
        if(Input.GetKeyDown(KeyCode.X)&&currentTime == 0){
            attacking = true;
            animator.SetTrigger("attack");
        }

        if(attacking){
            currentTime += Time.deltaTime;
            if(currentTime >= cooldown){
                attacking = false;
                currentTime = 0;
            }
            else if(currentTime >= timeAtt){
                attackArea.gameObject.SetActive(false);
            }

        }
    }

    void ActivarAtaque(){
        attackArea.gameObject.SetActive(true);
    }
    void DeactivateAtaque(){
        attackArea.gameObject.SetActive(false);
    }
}

