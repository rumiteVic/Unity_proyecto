using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Habilidades_Luz : MonoBehaviour
{
    public GameObject muroDeLuz;
    public GameObject bala;
    public GameObject boomLuz;
    public Movimiento suelin;
    public float speed;
    float dirige = 2;
    float izDe;
    float horizontal;
    bool muro;
    bool capa;
    public bool derecha;
    public bool suelo;

    //Cooldown muro
    bool murCol;
    float currTimMur = 0f;
    float finMur = 8f;

    //Cooldowns bala
    bool balCol;
    float currTimBal = 0f;
    float finBala = 3f;

    //Cooldowns explosion
    bool explCol;
    float currTimExpl = 0f;
    float finexPl = 15f;

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
        if (Input.GetKeyDown(KeyCode.S) &&suelin.suelo && currTimMur == 0)
        {
            muro = true; 
        }
        if (muro)
        {
            murCol = true;
            Vector2 direccion = new Vector2(transform.position.x + dirige * izDe, transform.position.y + 1.5f);
            GameObject tempMuro = Instantiate(muroDeLuz, direccion, transform.rotation);
            muro = false;
            Destroy(tempMuro, 7);
        }

        if(murCol)
        {
            currTimMur += Time.deltaTime;
            if(currTimMur  >= finMur){
                currTimMur  = 0;
                murCol = false;
            }
        }
 
        //Bala normal
        if (Input.GetKeyDown(KeyCode.Z) && currTimBal == 0)
        {
            balCol = true;
            GameObject objeto = Instantiate(bala, transform.position, transform.rotation);
            objeto.transform.rotation = Quaternion.Euler(0, 0, 90 * izDe);
            Destroy(objeto, 2);
        }
        if(balCol)
        {
            currTimBal += Time.deltaTime;
            if(currTimBal  >= finBala){
                currTimBal  = 0;
                balCol = false;
            }
        }

        //Explotemos algo
        if (Input.GetKeyDown(KeyCode.A) &&suelin.suelo &&currTimExpl == 0)
        {
            explCol = true;
            GameObject booooLuz = Instantiate(boomLuz, transform.position, transform.rotation);
            booooLuz.transform.localScale = new Vector2 (transform.localScale.x * 0.1f, transform.localScale.y * 0.1f);
            Destroy(booooLuz, 10);
        }

        if(explCol)
        {
            currTimExpl += Time.deltaTime;
            if(currTimExpl  >= finexPl){
                currTimExpl  = 0;
                explCol = false;
            }
        }
    }
}