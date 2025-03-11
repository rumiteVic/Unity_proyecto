using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgujeroNegro : MonoBehaviour
{
    // Start is called before the first frame update
    float fuerzaAtraccion = 50f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.attachedRigidbody != null && !other.CompareTag("Player"))
        {
            Vector2 direccion = (transform.position - other.transform.position);
            other.attachedRigidbody.AddForce(direccion * fuerzaAtraccion);
        }
    }
}
