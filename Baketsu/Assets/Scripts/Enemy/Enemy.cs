using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState {
    idle,
    walking, 
    attack, 
    stagger
}
public class Enemy : MonoBehaviour
{

    public EnemyState currentState;
    public int health;
    public string enemyName;
    public int baseAttack;

    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    private IEnumerator ColorChange(){
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }

    public void Knock(Rigidbody2D myRigidbody){
        health--;
        StartCoroutine(ColorChange());
        StartCoroutine(KnockCo(myRigidbody));
    }

    private IEnumerator KnockCo(Rigidbody2D myRigidbody)
    {
        
        yield return new WaitForSeconds(.3f);
    
        myRigidbody.velocity = Vector2.zero;
        currentState = EnemyState.walking;

        if(health <= 0){
            this.gameObject.SetActive(false);
        }
        
    }
}
