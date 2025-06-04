using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HUD : MonoBehaviour
{
    public Image[] vidas;
    public Image[] sinVidas;

    public GameObject restart;

    Life lifePlayer;

    public AudioSource uiSound;
    // Start is called before the first frame update
    void Start()
    {
        sinVidas[0].enabled = false;
        sinVidas[1].enabled = false;
        sinVidas[2].enabled = false;
        restart.gameObject.SetActive(false);
        lifePlayer = FindObjectOfType<Life>();
    }

    // Update is called once per frame
    void Update()
    {
        if(lifePlayer.currentVidas <= 0){
            restart.gameObject.SetActive(true);
            lifePlayer.zenith.gameObject.SetActive(false);
            Time.timeScale = 0;
        }
    }

    public void Reiniciar(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
