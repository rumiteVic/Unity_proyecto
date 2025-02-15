using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Habilidades_Luz : MonoBehaviour
{
    public GameObject muroDeLuz;
    public GameObject bala;
    public Movimiento suelin;
    public float speed;
    float dirige = 2;
    float izDe;
    float horizontal;
    bool muro;
    bool capa;
    public bool derecha;
    public bool suelo;
    // Start is called before the first frame update
    void Start()
    {
        derecha = true;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        if (horizontal < 0)
        {
            derecha = false;
        }
        else if(horizontal > 0)
        {
            derecha = true;
        }

        if(derecha){
            izDe =1f;
        }
        if(!derecha){
            izDe = -1f;
        }
        
        //El muro
        if (Input.GetKeyDown(KeyCode.X) &&suelin.suelo)
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
 
        //Bala normal
        if (Input.GetKeyDown(KeyCode.Z))
        {
            GameObject objeto = Instantiate(bala, transform.position, transform.rotation);
            objeto.transform.rotation = Quaternion.Euler(0, 0, 90 * izDe);
            Destroy(objeto, 2);
        }
    }
}