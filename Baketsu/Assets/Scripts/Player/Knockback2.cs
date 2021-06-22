using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback2 : MonoBehaviour
{
 [SerializeField] private float thrust;

 GameObject player;

void Start(){
   
}
 private void OnTriggerEnter2D(Collider2D collision)
 {
  if (collision.gameObject.CompareTag("Enemy"))
  {
        Rigidbody2D enemy = collision.GetComponent<Rigidbody2D>();
   
   if (enemy != null && enemy.GetComponent<Enemy>().currentState != EnemyState.stagger)
   {
     this.transform.parent.gameObject.GetComponent<PlayerController>().StartCoroutine(KnockCoroutine(enemy));
   }
  }
 }

 private IEnumerator KnockCoroutine(Rigidbody2D enemy )
 {
    enemy.GetComponent<Enemy>().currentState = EnemyState.stagger; 
    enemy.GetComponent<Enemy>().GetAttacked();
    Vector2 forceDirection = enemy.transform.position - transform.position;
    Vector2 force = forceDirection.normalized * thrust;

    enemy.velocity = force;
    yield return new WaitForSeconds(.3f);
    
    enemy.velocity = Vector2.zero;
    enemy.GetComponent<Enemy>().currentState = EnemyState.walking;
    if(enemy.GetComponent<Enemy>().health <= 0){
        enemy.gameObject.SetActive(false);
    }
    }
}