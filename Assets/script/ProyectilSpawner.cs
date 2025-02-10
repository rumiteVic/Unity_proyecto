using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilSpawner : MonoBehaviour
{

    public GameObject bala;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject objeto = Instantiate(bala, transform.position, transform.rotation);
            Destroy(objeto, 2);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {

           Destroy(gameObject);

        }
    }
}
