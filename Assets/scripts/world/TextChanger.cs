using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TextChanger : MonoBehaviour
{
    Pintar pinta;
    public TMP_Text objetosAPintar;
    public TMP_Text objetosPintados;
    public TMP_Text objetosADestruir;
    public TMP_Text objetosDestruidos;
    // Start is called before the first frame update
    void Start()
    {
        pinta = FindObjectOfType<Pintar>();
        objetosAPintar.text = pinta.pintarObjetos.ToString();
        objetosADestruir.text = pinta.destruirObjetos.ToString();
    }

    // Update is called once per frame
    public void ChangePintados(){
        objetosPintados.text = pinta.GetPintados().ToString();
    }

    public void ChangeDestruidos(){
        objetosDestruidos.text = pinta.GetDestruidos().ToString();
    }
}
