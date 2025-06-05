using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoryText : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject botton;
    private bool dialogueB = false;
    private bool dialogueStart = false;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text diagogueText;
    [SerializeField, TextArea(4,6)] private string[] dialogue;
    public Movimiento mov;
    private int lineIndex = 0;

    private float typingTime = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        botton.SetActive(false);
        dialoguePanel.SetActive(false);
        mov = FindObjectOfType<Movimiento>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)&& dialogueB){
            if(!dialogueStart){
                StartDialogue();
            }
            else if(diagogueText.text == dialogue[lineIndex]){
                NextDialogueLine();
            }
            else{
                StopAllCoroutines();
                diagogueText.text = dialogue[lineIndex];
            }
        }
    }

    private void StartDialogue(){
        dialogueStart = true;
        dialoguePanel.SetActive(true);
        botton.SetActive(false);
        lineIndex = 0;
        StartCoroutine(ShowLine());
        mov.canMove = false;
    }

    private void NextDialogueLine(){
        lineIndex++;
        if(lineIndex < dialogue.Length){
            StartCoroutine(ShowLine());
        }
        else{
            dialogueStart = false;
            dialoguePanel.SetActive(false);
            mov.canMove = true;
        }
    }

    private IEnumerator ShowLine(){
        diagogueText.text = string.Empty;
        foreach(char ch in dialogue[lineIndex]){
            diagogueText.text += ch;
            yield return new WaitForSeconds(typingTime);
        }
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Player"){
            botton.SetActive(true);
            dialogueB = true;
        }
    }
    void OnTriggerStay2D(Collider2D collision){
        if(collision.gameObject.tag == "Player"){
            botton.SetActive(true);
            dialogueB = true;
        }
        
    }

    void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.tag == "Player"){
            botton.SetActive(false);
            dialogueB = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Player"){
            botton.SetActive(true);
            dialogueB = true;
        }
    }
    void OnCollisionStay2D(Collision2D collision){
        if(collision.gameObject.tag == "Player"){
            botton.SetActive(true);
            dialogueB = true;
        }
        
    }

    void OnCollisionExit2D(Collision2D collision){
        if(collision.gameObject.tag == "Player"){
            botton.SetActive(false);
            dialogueB = false;
        }
    }
}
