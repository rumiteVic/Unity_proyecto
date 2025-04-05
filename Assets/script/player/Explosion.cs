using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    public Vector2 maxCrecimiento = new Vector2 (1.3f,1.3f);
    public float crece = 5f;
    float currTime = 0f;

    Vector2 inicio;
    // Start is called before the first frame update
    void Start()
    {
        inicio = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(currTime < crece)
        {
            currTime += Time.deltaTime;
            float huh = currTime / crece;
            transform.localScale = Vector2.Lerp(inicio, maxCrecimiento, huh);
        }
    }
}
