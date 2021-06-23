using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableFight : MonoBehaviour
{
    bool inRange;

    Collider2D player;
    public void OnTriggerEnter2D(Collider2D other){
        inRange = true;
        player = other;
    }

    public void OnTriggerExit2D(Collider2D other){
        inRange = false;
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.E) && player != null && inRange == true){
            EnableYoyo(player);
            Debug.Log("equiped");
        }
    }
    public void EnableYoyo(Collider2D other){
        other.gameObject.GetComponent<PlayerController>().fighting = true;
    }
}
