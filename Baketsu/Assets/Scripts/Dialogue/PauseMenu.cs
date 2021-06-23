using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    
    public GameObject controls;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab)){

            if(controls.active == false){
                controls.SetActive(true);
            }else{
                controls.SetActive(false);
            }

        }
    }
}
