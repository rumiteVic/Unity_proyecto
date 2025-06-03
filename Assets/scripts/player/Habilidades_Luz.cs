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
    public GameObject escudoJau;
    public Movimiento suelin;
    public Life life;
    float dirige = 2;
    bool muro;
    bool capa;
    public Animator animatorLuz;
    public Proyectil proyec;
    float direccionMirar = 1;
    //Cooldown muro
    bool murCol;
    float currTimMur = 0f;
    float finMur = 8f;

    //Cooldowns bala
    bool balCol;
    float currTimBal = 0f;
    float finBala = 1.5f;

    //Cooldowns explosion
    bool explCol;
    float currTimExpl = 0f;
    float finexPl = 10f;

    //Cooldowns escudo
    bool escudo;
    bool usoEscudo;
    float currTimEsc = 0f;
    float finEsc = 10f;

    // Start is called before the first frame update
    void Start()
    {
        escudoJau.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (suelin.srLuz.flipX) 
        {
            direccionMirar = -1f;
            proyec.izquierda = true;
        }
        if (!suelin.srLuz.flipX) 
        {
            direccionMirar = 1f;
            proyec.izquierda = false;
        }
 
        //Bala normal
        if (Input.GetKeyDown(KeyCode.Z) && currTimBal == 0)
        {
            animatorLuz.SetTrigger("lanzar");
            balCol = true;
            Vector2 direccion = new Vector2(transform.position.x +direccionMirar, transform.position.y - 0.5f);
            GameObject objeto = Instantiate(bala, direccion, transform.rotation);
            objeto.transform.rotation = Quaternion.Euler(0, 0, 90 * direccionMirar);
            Destroy(objeto, 10);
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
            animatorLuz.SetTrigger("lanzar");
            explCol = true;
            Vector2 direccion = new Vector2(transform.position.x + dirige * direccionMirar, transform.position.y - 1f);
            GameObject booooLuz = Instantiate(boomLuz, direccion, transform.rotation);
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

        //Escudo pero sin ser un escudo
        if (Input.GetKeyDown(KeyCode.B) && currTimEsc == 0)
        {
            animatorLuz.SetTrigger("lanzar");
            escudo = true;
            escudoJau.gameObject.SetActive(true);
        }
        if (escudo)
        {
            usoEscudo = true;
            escudo = false;
            suelin.escudoActivo = true;
        }

        if(usoEscudo)
        {
            currTimEsc += Time.deltaTime;
            if(currTimEsc  >= finEsc){
                currTimEsc  = 0;
                usoEscudo = false;
            }
        }
    }
}