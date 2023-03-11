using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // private EnemyMovement Movement;

    // private EnemyAttack Attack;

    public HealthScript Health;

    // public Transform target;

    // public HealthScript targetHealth;

    void Awake() {
        // Movement = GetComponent<EnemyMovement>();
        // Attack = GetComponent<EnemyAttack>();
        Health = GetComponent<HealthScript>();
        // targetHealth = target.GetComponent<HealthScript>();

    }
    void Start(){
        // Debug.Log(target.position);
        // Movement.setDestination(target.position);
    }

    void Update()
    {   
        // if(Movement.HasReachObjective()){
        //     Attack.Attack(targetHealth);
        // }
    }
}
