using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Habilidades_Luz : MonoBehaviour
{
    public GameObject muroDeLuz;
    public GameObject jaula;
    float dirige = 2;
    float izDe;
    float horizontal;
    bool muro;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        if (horizontal < 0)
        {
            izDe = -1f;
        }
        else if(horizontal > 0)
        {
            izDe = 1f;
        }
        else
        {
            izDe = 1f;
        }

            if (Input.GetKeyDown(KeyCode.S))
            {
                muro = true;
                
            }
            if (muro)
            {
                Vector2 direccion = new Vector2(transform.position.x + dirige * izDe, transform.position.y + 1.5f);
                GameObject tempMuro = Instantiate(muroDeLuz, direccion, transform.rotation);
                muro = false;
                Destroy(tempMuro, 7);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            muro = true;

        }
        if (muro)
        {
            Vector2 direccion = new Vector2(transform.position.x + dirige * izDe, transform.position.y);
            GameObject tempMuro = Instantiate(jaula, direccion, transform.rotation);
            muro = false;
            Destroy(tempMuro, 7);
        }
    }

    
}
