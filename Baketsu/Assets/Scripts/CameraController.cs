using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform target;
    public float smoothing;

    public Vector2 maxPosition;
    public Vector2 minPosition;



    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(8,-12,-10);
    }
    
    void LateUpdate(){
        if(transform.position != target.position){
            Vector3 targetPosition = new Vector3(target.position.x,
                                                target.position.y,
                                                transform.position.z);
            targetPosition.x = Mathf.Clamp(targetPosition.x,
                                            minPosition.x,
                                            maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y,
                                            minPosition.y,
                                            maxPosition.y);
            transform.position = Vector3.Lerp(transform.position,
                                                targetPosition,
                                                smoothing);
        }
    }

    public void SetMinPosition(Vector2 vector){
        minPosition = vector;
    }

    public void SetMaxPosition(Vector2 vector){
        maxPosition = vector;
    }
    
}