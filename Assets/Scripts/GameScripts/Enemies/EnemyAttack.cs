using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private Animator animator;
    private int damage = 25;

    void Awake(){
        animator = GetComponent<Animator>();
    }

    public void Attack(Transform enemy){
        HealthScript enemyHealth = enemy.GetComponent<HealthScript>();
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            enemyHealth.TakeDamage(damage);
        if(!stateInfo.IsName("Roar")){
            animator.Play("Roar");
        }

    }
}
