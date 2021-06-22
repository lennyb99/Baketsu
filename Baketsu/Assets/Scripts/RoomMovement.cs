using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMovement : MonoBehaviour
{

    public Vector2 cameraChange;

    public Vector3 playerChange;

    public Vector2 maxPosition;
    public Vector2 minPosition;

    private CameraController cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other){

        if(other.CompareTag("MovementHitbox")){
            cam.SetMaxPosition(maxPosition);
            cam.SetMinPosition(minPosition);
            
            GameObject player = other.transform.parent.gameObject;
            player.transform.position += playerChange;
            
            
        }

    }

}
