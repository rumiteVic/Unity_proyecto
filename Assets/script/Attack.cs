using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    public Transform attackArea;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            attackArea.gameObject.SetActive(true);
            Debug.Log("Pressed left click.");
        }
        else
        {
            attackArea.gameObject.SetActive(false);
        }

    }
}
