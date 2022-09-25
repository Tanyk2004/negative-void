using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackDamage : MonoBehaviour
{
    public float timeBetweenAttack;
    public float startTimeBetweenAttack;

    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemies;
    public int damage;

    public Animator animator;
    void Update(){

        if (timeBetweenAttack <= 0){
            
            if (Input.GetKeyDown(KeyCode.F)){
                //attack
                Debug.Log("Attack");
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, 
                attackRange, whatIsEnemies);

                for( int i = 0; i < enemiesToDamage.Length; i++){

                    if( enemiesToDamage[i].gameObject.tag == "mob"){
                        animator.SetTrigger("Attack");
                        enemiesToDamage[i].GetComponent<mobController>().takeDamage(damage);
                    }
                    
                }
                timeBetweenAttack = startTimeBetweenAttack;
            }
            
        } else {
            timeBetweenAttack -= Time.deltaTime;
        }
    }
   

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
