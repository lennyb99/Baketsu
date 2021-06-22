using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brokkoli : Enemy
{
   public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePos;


    private Rigidbody2D myRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        currentState = EnemyState.idle;
        myRigidbody = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckDistance();
    }

   

    

    void CheckDistance(){
        if(Vector3.Distance(target.position,transform.position)<= chaseRadius &&
                Vector3.Distance(target.position, transform.position)>= attackRadius && currentState != EnemyState.stagger && currentState != EnemyState.attack){
            Vector3 temp = Vector3.MoveTowards(transform.position,target.position, moveSpeed * Time.deltaTime);
            myRigidbody.MovePosition(temp);
            
        }
    }

    private void ChangeState(EnemyState newState){
        if(currentState != newState){
            currentState = newState;
        }
    }
}
