using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class ChangeLight : MonoBehaviour
{
    public bool siLuz = true;
    public Habilidades_Luz lucecita;
    public HabilidadesSombra sombra;
    public Movimiento move;
    public AnimatorController animationLuz;
    public AnimatorController animationSombra;
    public Animator anim;

    private SpriteRenderer sprLuz;
    private SpriteRenderer sprSombra;
    float cooldownUsoCapa;
    bool capa;


    // Start is called before the first frame update
    void Start()
    {
        move = GetComponent<Movimiento>();
        anim = GetComponent<Animator>();
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
            anim.runtimeAnimatorController = animationLuz;
            sombra.enabled = false;
            lucecita.enabled=true;
            sombra.cooldownUsoCapa = 0f;
            sombra.capa = false;
            move.spr = sprLuz;
        }
        if (!siLuz)
        {
            anim.runtimeAnimatorController = animationSombra;
            sombra.enabled = true;
            lucecita.enabled = false;
            move.spr = sprSombra;
        }
    }
}
