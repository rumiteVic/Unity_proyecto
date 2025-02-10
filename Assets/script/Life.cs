using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public static Life instance; 

    public int vidas = 3; 
    
     
    void Awake()
    {

        instance = this; 
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
