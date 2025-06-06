using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySpawn : MonoBehaviour
{

    public GameObject slime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnDestroy(){
        Quaternion rotation = Quaternion.Euler(0, 0, 0);
        GameObject slimey = Instantiate(slime, transform.position, rotation);
    }
}
