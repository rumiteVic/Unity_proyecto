using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class siguePlayer : MonoBehaviour
{
    GameObject zenith;
    Vector2 position;

    public GameObject escudo;

    public float crece = 5f;
    float currTime = 0f;
    float inicio = 0;
    float maxCrecimiento = 360;
    // Start is called before the first frame update
    void Start()
    {
        zenith = GameObject.Find("Zenith");
        Destroy(escudo, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        position = new Vector2(zenith.transform.position.x, zenith.transform.position.y + 2f);
        escudo.transform.position = position;


        if(currTime < crece)
        {
            currTime += Time.deltaTime;
            float huh = currTime / crece;
            float rotate = Mathf.Lerp(inicio, maxCrecimiento, huh);
            transform.rotation = Quaternion.Euler(0f, 0f, rotate);
        }
    }
}
