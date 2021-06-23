using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableFight : MonoBehaviour
{
    bool inRange;

    Collider2D player;
    public void OnTriggerEnter2D(Collider2D other){
        EnableYoyo(other);
    }

   

    
    public void EnableYoyo(Collider2D other){
        other.gameObject.GetComponent<PlayerController>().fighting = true;
    }
}
