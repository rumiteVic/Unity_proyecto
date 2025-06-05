using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieParticulas : MonoBehaviour
{
    public GameObject particula;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy(){
        GameObject particula1 = Instantiate(particula, transform.position, transform.rotation);
    }
}
