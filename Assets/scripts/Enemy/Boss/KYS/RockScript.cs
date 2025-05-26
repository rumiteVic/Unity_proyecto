using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockScript : MonoBehaviour
{
    private Collider2D collider;
    public float counter;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        counter += Time.deltaTime;
        if (counter >= 1)
        {
            this.GetComponent<SpriteRenderer>().color = new Color(0,0,0,255);
            collider.enabled = true;
        }
        if(counter >= 2)
        {
            Destroy(this.gameObject);
        }
    }
}
