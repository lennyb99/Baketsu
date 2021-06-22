using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState {
    walking,
    stopped,
    attacking,
    stagger
}
public class PlayerController : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float moveSpeed;
    private Vector3 moveDirection;

    public PlayerState playerState;

    private Animator animator;

    Camera mainCam;

    


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
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
        AnimatePlayer();
    }

    void ProcessInputs()
    {   
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");



        if(Input.GetButtonDown("Attack")&&playerState != PlayerState.attacking && playerState != PlayerState.stopped){
            StartCoroutine(AttackCo());
        }else if(playerState == PlayerState.walking){
            moveDirection = new Vector3(moveX, moveY, myRigidbody.transform.position.z).normalized;
        }

    }

    private IEnumerator AttackCo(){
        playerState = PlayerState.attacking;
        animator.SetBool("attacking", true);
        yield return null;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(0.15f);
        playerState = PlayerState.walking;
    }


    void MovePlayer()
    {
        if(playerState!=PlayerState.stopped && playerState!=PlayerState.stagger){
            myRigidbody.MovePosition(transform.position + moveDirection * moveSpeed * Time.deltaTime);
        }
    }


    public void Knock(){
        StartCoroutine(KnockCo());
    }
    private IEnumerator KnockCo()
    {
        if(myRigidbody != null){

            yield return new WaitForSeconds(.3f);
            myRigidbody.velocity = Vector2.zero;
            playerState = PlayerState.walking;
        }
    }

    void AnimatePlayer(){
        if(moveDirection != Vector3.zero){
            animator.SetFloat("walkX", moveDirection.x);
            animator.SetFloat("walkY", moveDirection.y);
            animator.SetBool("walking", true);
        }else{
            animator.SetBool("walking", false);
        }
    }

    public void SetPlayerState(PlayerState plState){
        playerState = plState;
    }

    
}
