using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text dialogueText;

    public Image speaker;
    private Queue<string> sentences;
    private Queue<Sprite> portraits;
    private Queue<bool> positions;

    public GameObject dialogueBox;

    private bool diaBoxInScreen;

    public GameObject player;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        portraits = new Queue<Sprite>();
        positions = new Queue<bool>(); 
    }

    public void StartDialogue(Dialogue dialogue){
        
        // Dialogbox Fade-in
        animator.SetBool("isOpen", true);
        speaker.gameObject.SetActive(true);

        // Spieler stoppen
        player.gameObject.GetComponent<PlayerController>().SetPlayerState(PlayerState.stopped);
        
        // Die Queues frei machen, um neuen Dialog zu laden
        positions.Clear();
        sentences.Clear();
        portraits.Clear();

        // Hinzufügen der Werte aus dem Dialog Objekt in die Queues des Dialogmanagers
        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        foreach(Sprite portrait in dialogue.portraits){
            portraits.Enqueue(portrait);
        }
        foreach(bool right in dialogue.right){
            positions.Enqueue(right);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence(){
        
        // Kontrolle, ob noch Sätze in der Queue über sind.
        if(sentences.Count==0){
            EndDialogue();
            return;
        }

        // Die Werte für die nächste Aussage aus der Queue holen
        string sentence = sentences.Dequeue();
        Sprite portrait = portraits.Dequeue();
        bool right = positions.Dequeue();

        // Ausgabe der Aussage
        StopAllCoroutines(); // Für den Fall, dass der Nutzer vorzeitig die nächste Aussage aufruft.
        StartCoroutine(TypeSentence(sentence,portrait,right));
    }

    IEnumerator TypeSentence(string sentence, Sprite portrait, bool right){
        
        // Warten, bis die Dialogbox vollständig reingefahren ist. If Abfrage, um zu prüfen, ob sie nicht schon geladen ist.
        // Falls sie geladen ist, überspringe. Falls nicht, dann warten und sie dann auf aktiv setzen.
        if(!diaBoxInScreen){
            yield return new WaitForSeconds(0.25f);
            diaBoxInScreen = true;
        }
        

        // Die Position des Bildes vom Sprecher setzen
        /*
        if(!right){
            speaker.transform.localPosition = new Vector3(-1690,133,0);
        }else{
            speaker.transform.localPosition = new Vector3(-173,133,0);
        }
        */

        // Das Bild des Sprechers setzen
        speaker.sprite = portrait;

        // Text leer setzen und dann nacheinander jeden Buchstaben hinzufügen
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray()){
            dialogueText.text += letter;
            yield return new WaitForSeconds(.02f);
        }
    }

    public void EndDialogue(){

        // Dialogbox Fade-out
        animator.SetBool("isOpen", false);

        // Spielerbewegung aktiviert
        player.gameObject.GetComponent<PlayerController>().SetPlayerState(PlayerState.walking);
        
        // Zurücksetzen der Dialogbox
        dialogueText.text = "";
        speaker.sprite = null;
        diaBoxInScreen = false;

        speaker.gameObject.SetActive(false);
    }

}
