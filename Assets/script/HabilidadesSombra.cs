using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabilidadesSombra : MonoBehaviour
{
    public GameObject jaula;
    public GameObject balaOscura;
    public Movimiento suelo;
    public float speed;
    float dirige = 2;
    float izDe;
    float horizontal;
    bool muro;
    bool capa;
    public bool derecha;
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
        if (Input.GetKeyDown(KeyCode.S))
        {
            muro = true;

        }
        if (muro)
        {
            Vector2 direccion = new Vector2(transform.position.x + dirige * izDe, transform.position.y);
            GameObject tempMuro = Instantiate(jaula, direccion, transform.rotation);
            muro = false;
            Destroy(tempMuro, 7);
        }
        //Bala oscura
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject objetoOscuro = Instantiate(balaOscura, transform.position, transform.rotation);
            objetoOscuro.transform.rotation = Quaternion.Euler(0, 0, 90 * izDe);
            Destroy(objetoOscuro, 2);
        }

        //Capa Oscuridad, supongo

        if (Input.GetKeyDown(KeyCode.B))
        {

        }
    }
}
