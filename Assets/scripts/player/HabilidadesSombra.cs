using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabilidadesSombra : MonoBehaviour
{
    public GameObject jaula;
    public GameObject balaOscura;
    public GameObject boomOscuridad;
    public Movimiento suelin;
    public Proyectil proyec;
    public bool suelo;
    float dirige = 2;
    float direccionMirar = 1;
    bool jaulaa;
    public bool capa;

    public GameObject particula;
    //Tiempo de uso de capa
    public float cooldownUsoCapa = 0f;
    float fin = 7f;

    //Cooldown capa
    bool capCol;
    float currTimCap = 0f;
    float finCap = 10f;

    //Cooldown jaula
    bool jauCol;
    float currTimJau = 0f;

    //Cooldows bala
    bool balCol;
    float currTimBal = 0f;
    float finBala = 1.5f;

    public Animator animatorOsc;

    // Start is called before the first frame update
    void Start()
    {
        particula.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (suelin.srOsc.flipX) 
        {
            direccionMirar = -1f;
            proyec.izquierda = true;
        }
        if (!suelin.srOsc.flipX) 
        {
            direccionMirar = 1f;
            proyec.izquierda = false;
        }

        //Bala oscura
        if (Input.GetKeyDown(KeyCode.Z) && currTimBal == 0)
        {
            animatorOsc.SetTrigger("lanzar");
            balCol = true;
            Vector2 direccion = new Vector2(transform.position.x +direccionMirar, transform.position.y - 0.5f);
            GameObject objetoOscuro = Instantiate(balaOscura, direccion, transform.rotation);
            objetoOscuro.transform.rotation = Quaternion.Euler(0, 0, 90 * direccionMirar);
            Destroy(objetoOscuro, 10);
        }
        
        if(balCol)
        {
            currTimBal += Time.deltaTime;
            if(currTimBal  >= finBala){
                currTimBal  = 0;
                balCol = false;
            }
        }

        //Capa Oscuridad, supongo

        if (Input.GetKeyDown(KeyCode.B) && currTimCap == 0)
        {
            animatorOsc.SetTrigger("lanzar");
            capa = true;
            capCol = true;
            
        }
        if(capa){
            cooldownUsoCapa  += Time.deltaTime;
            particula.gameObject.SetActive(true);
            if(cooldownUsoCapa  >= fin){
                cooldownUsoCapa  = 0;
                capa = false;
                particula.gameObject.SetActive(false);
            }
        }
        
        if(capCol)
        {
            currTimCap += Time.deltaTime;
            if(currTimCap  >= finCap){
                currTimCap  = 0;
                capCol = false;
            }
        }
    }
}
