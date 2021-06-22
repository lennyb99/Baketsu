using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum attackStatus{
    ready,
    attacking
}
public class Knockback : MonoBehaviour
{

    public attackStatus status;
    public float thrust;
    public float knocktime;
    
    void Start(){
        status = attackStatus.ready;
    }
    public void OnTriggerEnter2D(Collider2D other){
        
        if(other.gameObject.CompareTag("Enemy") && status == attackStatus.ready){
            GameObject enemy = other.gameObject;
            
            status = attackStatus.attacking;
            Rigidbody2D enemyBody =  other.GetComponent<Rigidbody2D>();
            
            if(enemyBody != null){
                
                enemyBody.isKinematic = false;
                Vector2 difference = enemyBody.transform.position - transform.position;
                difference = difference.normalized * thrust;
                enemyBody.AddForce(difference, ForceMode2D.Impulse);
                StartCoroutine(KnockCo(enemyBody, enemy));

            }
        }
    }

    private IEnumerator KnockCo(Rigidbody2D enemyBody, GameObject enemy){
        if(enemyBody != null){
            
            
            
            yield return new WaitForSeconds(knocktime);
            Debug.Log("done");
            enemyBody.velocity = Vector2.zero;
            enemyBody.isKinematic = true;
            status = attackStatus.ready;
            
        }
    }

}
