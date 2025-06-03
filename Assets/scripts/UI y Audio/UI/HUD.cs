using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HUD : MonoBehaviour
{
    public Image[] vidas;
    public Image[] sinVidas;


    public AudioSource uiSound;
    // Start is called before the first frame update
    void Start()
    {
        sinVidas[0].enabled = false;
        sinVidas[1].enabled = false;
        sinVidas[2].enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }


}
