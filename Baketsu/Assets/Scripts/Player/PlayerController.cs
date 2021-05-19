using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState {
    walking,
    stopped
}
public class PlayerController : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float moveSpeed;
    private Vector3 moveDirection;

    public PlayerState playerState;

    


    // Start is called before the first frame update
    void Start()
    {
        playerState = PlayerState.walking;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector3(moveX, moveY, myRigidbody.transform.position.z).normalized;
    }

    void MovePlayer()
    {
        if(playerState!=PlayerState.stopped){
            myRigidbody.MovePosition(transform.position + moveDirection * moveSpeed * Time.deltaTime);
        }
    }

    public void SetPlayerState(PlayerState plState){
        playerState = plState;
    }

    
}
