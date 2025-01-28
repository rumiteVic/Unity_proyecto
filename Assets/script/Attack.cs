using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    public Transform attackArea;
    private float cooldown = 1f;
    // Start is called before the first frame update
    void Start()
    {
        attackArea.gameObject.SetActive(false);
        
    }
    void Update()
    {
        StartCoroutine(attack());
    }

    // Update is called once per frame
    private IEnumerator attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            attackArea.gameObject.SetActive(true);
            Debug.Log("Pressed left click.");
            yield return new WaitForSeconds(cooldown);
            attackArea.gameObject.SetActive(false);
        }

    }
}
