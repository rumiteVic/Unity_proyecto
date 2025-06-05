using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class FaltanCosas : MonoBehaviour
{
    public GameObject botton;
    private bool dialogueB = false;
    private bool dialogueStart = false;
    private bool lineFinished = false;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(4,6)] public string[] dialogue = {
    "¡Hola! Te faltan {FALTAN_PINTAR} objetos para continuar.",
    "¡Ánimo, estás cerca!"
};

    [SerializeField, TextArea(4,6)] public string[] dialogueNormal = {};
    private string[] textoActual;

    public Pintar pinta;
    public Movimiento mov;
    private int lineIndex = 0;

    private float typingTime = 0.05f;

    private string currentProcessedLine = "";
    // Start is called before the first frame update
    void Start()
    {
        botton.SetActive(false);
        dialoguePanel.SetActive(false);
        mov = FindObjectOfType<Movimiento>();
        pinta = FindObjectOfType<Pintar>();
    }

    // Update is called once per frame
    void Update()
{
    if(Input.GetKeyDown(KeyCode.F) && dialogueB){
        if(!dialogueStart){
            StartDialogue();
        }
        else if(lineFinished){
            NextDialogueLine();
        }
        else{
            StopAllCoroutines();
            dialogueText.text = currentProcessedLine;
            lineFinished = true;
        }
    }
}

    private void StartDialogue(){
        dialogueStart = true;
        dialoguePanel.SetActive(true);
        botton.SetActive(false);
        lineIndex = 0;
        mov.canMove = false;
        StartCoroutine(ShowLine());
    }

    private void NextDialogueLine(){
        lineIndex++;
        if(lineIndex < textoActual.Length){
            StartCoroutine(ShowLine());
        }
        else{
            dialogueStart = false;
            dialoguePanel.SetActive(false);
            mov.canMove = true;
        }
    }

    private IEnumerator ShowLine(){
        dialogueText.text = string.Empty;
        lineFinished = false; 

        string rawLine = textoActual[lineIndex];
        int faltanPintar = pinta.FaltaPintar();
        int faltanDestruir = pinta.FaltaDestruir();

        currentProcessedLine = rawLine
            .Replace("{FALTAN_PINTAR}", faltanPintar.ToString())
            .Replace("{FALTAN_DESTRUIR}", faltanDestruir.ToString());

        foreach(char ch in currentProcessedLine){
            dialogueText.text += ch;
            yield return new WaitForSeconds(typingTime);
        }

        lineFinished = true; 
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Player"){
            botton.SetActive(true);
            dialogueB = true;
            if(pinta.objetosDestruidos < pinta.destruirObjetos || pinta.objetosPintado < pinta.pintarObjetos){
                textoActual = dialogue;
            }
            else{
                textoActual = dialogueNormal;
            }
        }
    }
    void OnTriggerStay2D(Collider2D collision){
        if(collision.gameObject.tag == "Player"){
            botton.SetActive(true);
            dialogueB = true;
            if(pinta.objetosDestruidos < pinta.destruirObjetos || pinta.objetosPintado < pinta.pintarObjetos){
                textoActual = dialogue;
            }
            else{
                textoActual = dialogueNormal;
            }
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
            if(pinta.objetosDestruidos < pinta.destruirObjetos || pinta.objetosPintado < pinta.pintarObjetos){
                textoActual = dialogue;
            }
            else{
                textoActual = dialogueNormal;
            }
        }
    }
    void OnCollisionStay2D(Collision2D collision){
        if(collision.gameObject.tag == "Player"){
            botton.SetActive(true);
            dialogueB = true;
            if(pinta.objetosDestruidos < pinta.destruirObjetos || pinta.objetosPintado < pinta.pintarObjetos){
                textoActual = dialogue;
            }
            else{
                textoActual = dialogueNormal;
            }
        }
        
    }

    void OnCollisionExit2D(Collision2D collision){
        if(collision.gameObject.tag == "Player"){
            botton.SetActive(false);
            dialogueB = false;
        }
    }
}
