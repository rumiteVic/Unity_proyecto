using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pintar : MonoBehaviour
{
    public int pintarObjetos = 3;
    public int objetosPintado = 0;

    public int destruirObjetos = 3;
    public int objetosDestruidos = 0;

    // Update is called once per frame
    public void SumarPintados()
    {
        objetosPintado++;
    }

    public int FaltaPintar(){
        return pintarObjetos - objetosPintado;
    }

    public int GetPintados(){
        return objetosPintado;
    }

    public void SumarDestruidos()
    {
        objetosDestruidos++;
    }

    public int FaltaDestruir(){
        return destruirObjetos - objetosDestruidos;
    }

    public int GetDestruidos(){
        return objetosDestruidos;
    }
}
