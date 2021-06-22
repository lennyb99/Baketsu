using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback2 : MonoBehaviour
{
    [SerializeField] private float thrust;

    GameObject player;

    void Start(){
   
    }


    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Player")){
            Rigidbody2D hit = collision.GetComponent<Rigidbody2D>();
   
            if (hit != null){
                if(collision.gameObject.CompareTag("Enemy")){
                    
                    if(hit.GetComponent<Enemy>().currentState != EnemyState.stagger){
                        hit.GetComponent<Enemy>().currentState = EnemyState.stagger; 
                        hit.GetComponent<Enemy>().Knock(hit);
                        //this.transform.parent.gameObject.GetComponent<PlayerController>().StartCoroutine(KnockCoroutine(hit));

                        Vector2 forceDirection = hit.transform.position - transform.position;
                        Vector2 force = forceDirection.normalized * thrust;

                        hit.velocity = force;
                    }
                }else if(collision.gameObject.CompareTag("Player")){
                    if(
                        hit.GetComponent<PlayerController>().playerState != PlayerState.stagger){
                        hit.GetComponent<PlayerController>().playerState = PlayerState.stagger;
                        hit.GetComponent<PlayerController>().Knock();

                        Vector2 difference = hit.transform.position - transform.position;
                        difference = difference.normalized * thrust;

                        hit.AddForce(difference, ForceMode2D.Impulse);
                        Debug.Log("player got hit");
                    }
                }
            }
            
            
            
        }
    }

    private IEnumerator KnockCoroutine(Rigidbody2D enemy )
    {
        
        yield return new WaitForSeconds(.3f);
    
        enemy.velocity = Vector2.zero;
        enemy.GetComponent<Enemy>().currentState = EnemyState.walking;
        if(enemy.GetComponent<Enemy>().health <= 0){
            enemy.gameObject.SetActive(false);
        }
    }
}