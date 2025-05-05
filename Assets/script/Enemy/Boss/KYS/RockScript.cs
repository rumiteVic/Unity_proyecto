using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockScript : MonoBehaviour
{

    public float counter;
    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if (counter >= 1)
        {
            this.GetComponent<SpriteRenderer>().color = new Color(0,0,0,255);
        }
        if(counter >= 2)
        {
            Destroy(this.gameObject);
        }
    }
}