using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    public bool presence;

    void OnTriggerEnter(Collider other)
    {
        presence = true;
    }

    void OnTriggerExit(Collider other)
    {
        presence = false;
    }

    void OnTriggerStay(Collider other)
    {
        presence = true;
    }

}
