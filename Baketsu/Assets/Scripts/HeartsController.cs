using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartsController : MonoBehaviour
{

    public GameObject player;

    private int health;

    public Image heart1;
    public Image heart2;
    public Image heart3;
    public Image heart4;
    public Image heart5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        health = player.GetComponent<PlayerController>().GetHealth();

        UpdateHearts();
    }

    private void UpdateHearts(){
        if(health >= 1){
            heart1.enabled = true;
            if(health >= 2){
                heart2.enabled = true;
                if(health >= 3){
                    heart3.enabled = true;
                    if(health >= 4){
                        heart4.enabled = true;
                        if(health == 5){
                            heart5.enabled = true;
                        }else{
                            heart5.enabled = false;
                        }
                    } else{
                        heart4.enabled = false;
                    }
                }else{
                    heart3.enabled = false;
                }
            }else{
                heart2.enabled = false;
            }
        }else{
            heart1.enabled = false;
        }
    }
}
