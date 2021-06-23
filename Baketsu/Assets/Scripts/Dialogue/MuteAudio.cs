using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteAudio : MonoBehaviour
{
    public bool playing;

    void Start(){
        playing = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M)){
            
            
            if(playing){
                Camera.main.GetComponent<AudioSource>().Pause();
                playing = false;
            }else{
                Camera.main.GetComponent<AudioSource>().Play();
                playing = true;
            }

        }
    }
}
