using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private Animator animator;
    private int damage = 25;
    // Start is called before the first frame update
    void Awake(){
        animator = GetComponent<Animator>();
    }

    public void Attack(Transform enemy){
        // HealthScript enemyHealth = enemy.GetComponent<HealthScript>();
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if(!stateInfo.IsName("Roar")){
            // enemyHealth.TakeDamage(damage);
            animator.Play("Roar");
        }

    }
}
