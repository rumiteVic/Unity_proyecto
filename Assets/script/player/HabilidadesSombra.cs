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
    float izDe;
    float horizontal;
    bool jaulaa;
    public bool capa;
    public bool derecha;

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

    //Cooldowns explosion
    bool explCol;
    float currTimExpl = 0f;
    float finexPl = 10f;

    public Animator animatorOsc;

    // Start is called before the first frame update
    void Start()
    {
        derecha = true;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        if (horizontal < 0) {derecha = false;}
        if (horizontal > 0) {derecha = true;}
        if (!derecha) 
        {
            izDe = -1f;
            proyec.izquierda = true;
        }
        if (derecha) 
        {
            izDe = 1f;
            proyec.izquierda = false;
        }

        

        //Jaula
        if (Input.GetKeyDown(KeyCode.S) &&suelin.suelo && currTimJau == 0)
        {
            animatorOsc.SetTrigger("lanzar");
            jaulaa = true;
            jauCol = true;
        }
        if (jaulaa)
        {
            Vector2 direccion = new Vector2(transform.position.x + dirige * izDe, transform.position.y - 1.5f);
            GameObject tempJaula = Instantiate(jaula, direccion, transform.rotation);
            jaulaa = false;
            Destroy(tempJaula, 4);
        }

        if(jauCol)
        {
            currTimJau += Time.deltaTime;
            if(currTimJau  >= finCap)
            {
                currTimJau  = 0;
                jauCol = false;
            }
        }

        //Bala oscura
        if (Input.GetKeyDown(KeyCode.Z) && currTimBal == 0)
        {
            animatorOsc.SetTrigger("lanzar");
            balCol = true;
            Vector2 direccion = new Vector2(transform.position.x +izDe, transform.position.y - 0.5f);
            GameObject objetoOscuro = Instantiate(balaOscura, direccion, transform.rotation);
            objetoOscuro.transform.rotation = Quaternion.Euler(0, 0, 90 * izDe);
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

            if(cooldownUsoCapa  >= fin){
                cooldownUsoCapa  = 0;
                capa = false;
                
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

        //Explotemos algo
        if (Input.GetKeyDown(KeyCode.A) &&suelin.suelo && currTimExpl == 0)
        {
            animatorOsc.SetTrigger("lanzar");
            explCol = true;
            Vector2 direccion = new Vector2(transform.position.x + dirige * izDe, transform.position.y - 1f);
            GameObject booooOsc = Instantiate(boomOscuridad, direccion, transform.rotation);
            booooOsc.transform.localScale = new Vector2 (transform.localScale.x * 0.1f, transform.localScale.y * 0.1f);
            Destroy(booooOsc, 10);
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
