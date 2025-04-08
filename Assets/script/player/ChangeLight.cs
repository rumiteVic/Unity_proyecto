using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLight : MonoBehaviour
{
    public bool siLuz = true;
    public GameObject luz;
    public GameObject oscuridad;
    public Habilidades_Luz lucecita;
    public HabilidadesSombra sombra;
    public Movimiento move;

    private SpriteRenderer sprLuz;
    private SpriteRenderer sprSombra;
    float cooldownUsoCapa;
    bool capa;


    // Start is called before the first frame update
    void Start()
    {
        move = GetComponent<Movimiento>();
        sprLuz = luz.GetComponent<SpriteRenderer>();
        sprSombra = oscuridad.GetComponent<SpriteRenderer>();

        move.spr = sprLuz;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab)) 
        {
            if(siLuz)
            {
                siLuz = false;
            }
            else if (!siLuz)
            {
                siLuz=true;
            }
        }

        if (siLuz)
        {
            oscuridad.gameObject.SetActive(false);
            sombra.enabled = false;
            luz.gameObject.SetActive(true);
            lucecita.enabled=true;
            sombra.cooldownUsoCapa = 0f;
            sombra.capa = false;
            move.spr = sprLuz;
        }
        if (!siLuz)
        {
            oscuridad.gameObject.SetActive(true);
            sombra.enabled = true;
            luz.gameObject.SetActive(false);
            lucecita.enabled = false;
            move.spr = sprSombra;
        }
    }
}
