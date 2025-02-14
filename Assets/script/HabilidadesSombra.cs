using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabilidadesSombra : MonoBehaviour
{
    public GameObject jaula;
    public GameObject balaOscura;
    public Movimiento suelin;
    public bool suelo;
    public float speed;
    float dirige = 2;
    float izDe;
    float horizontal;
    bool jaulaa;
    public bool capa = false;
    public bool derecha;
    float cooldown = 0f;
    float fin = 5f;
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
        else if (horizontal > 0)
        {
            derecha = true;
        }

        if (derecha)
        {
            izDe = 1f;
        }
        if (!derecha)
        {
            izDe = -1f;
        }
        

        //Jaula
        if (Input.GetKeyDown(KeyCode.S) &&suelin.suelo)
        {
            jaulaa = true;

        }
        if (jaulaa)
        {
            Vector2 direccion = new Vector2(transform.position.x + dirige * izDe, transform.position.y);
            GameObject tempJaula = Instantiate(jaula, direccion, transform.rotation);
            jaulaa = false;
            Destroy(tempJaula, 7);
        }
        //Bala oscura
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject objetoOscuro = Instantiate(balaOscura, transform.position, transform.rotation);
            objetoOscuro.transform.rotation = Quaternion.Euler(0, 0, 90 * izDe);
            Destroy(objetoOscuro, 2);
        }

        //Capa Oscuridad, supongo

        if (Input.GetKeyDown(KeyCode.B) &&cooldown == 0)
        {
            capa = true;
            
        }
        if(capa){
            cooldown += Time.deltaTime;
            if(cooldown >= fin){
                cooldown = 0;
                capa = false;
            }
        }
    }
}
