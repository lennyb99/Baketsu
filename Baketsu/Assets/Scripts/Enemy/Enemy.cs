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

    public void GetAttacked(){
        health--;
        StartCoroutine(ColorChange());
    }

    private IEnumerator ColorChange(){
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }
}
