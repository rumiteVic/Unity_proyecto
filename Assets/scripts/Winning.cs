using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winning : MonoBehaviour
{
    public GameObject winner;
    public GameObject ui;
    // Start is called before the first frame update
    void Start()
    {
        winner.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Player"){
            winner.SetActive(true);
            ui.SetActive(false);
            Time.timeScale = 0f;
        }
    }
}
