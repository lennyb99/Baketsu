using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialoguePartner : MonoBehaviour
{

    public bool playerInRange;
    public bool inDialogue;

    private GameObject player;

    public Dialogue dialogue;

    // Start is called before the first frame update
    void Start()
    {
        playerInRange = false;
        inDialogue = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)&& playerInRange && inDialogue == false){
            inDialogue = true;
            startDialogue();
        }else if(Input.GetKeyDown(KeyCode.E) && inDialogue == true){
            inDialogue = false;
            endDialogue();
        }
    }

    public void TriggerDialogue(){
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("ChatHitbox")){
            playerInRange = true;
            player = other.gameObject;     
        } 
    }

    public void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("ChatHitbox")){
            playerInRange = false;
            inDialogue = false;
        }
    }

    private void startDialogue(){
        TriggerDialogue();
    }

    private void endDialogue(){
        FindObjectOfType<DialogueManager>().EndDialogue();
    }
}
