using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Life lifes;

    public GameObject restart;

    void Start()
    {
        restart.gameObject.SetActive(false);
    }

    void Update()
    {

        if(lifes.currentVidas <= 0)
        {
           restart.gameObject.SetActive(true);
        }
        else
        {
            restart.gameObject.SetActive(false);
        }
    }

    public void RestartGame()
    {
        Debug.Log("Game Re-Started");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

