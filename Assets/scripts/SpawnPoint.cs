using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public Vector2 position;
    public GameObject spawnPosition;
    Movimiento mov;
    public Collider2D coll;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        position = new Vector2(spawnPosition.transform.position.x, spawnPosition.transform.position.y);
        mov = FindObjectOfType<Movimiento>();
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Player"){
            mov.spawnPlace = new Vector2 (position.x, position.y);
            coll.enabled = false;
            animator.SetBool("abrazo", true);
        }
    }
}
