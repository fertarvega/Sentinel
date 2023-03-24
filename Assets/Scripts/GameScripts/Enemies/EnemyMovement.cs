using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class EnemyMovement : MonoBehaviour
{
    private Animator animator;
    private UnityEngine.AI.NavMeshAgent navMesh;
    [SerializeField] private float movementSpeed = 1.5f;
    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        navMesh = GetComponent<UnityEngine.AI.NavMeshAgent>();
        navMesh.stoppingDistance = 1.0f; // set stopping distance to 2 meter
        navMesh.speed = movementSpeed;
    }

    private void Update() {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if(!stateInfo.IsName("Roar") && (navMesh.velocity != Vector3.zero)){
            // enemyHealth.TakeDamage(damage);
            animator.Play("Walk Forward W Root");
        }
    }

    public void setDestination(Vector3? destination){
        if (destination.HasValue){
                navMesh.destination = destination.Value;
            }
    }

    public bool HasReachObjective(){
        return (!navMesh.pathPending && navMesh.remainingDistance <= navMesh.stoppingDistance);
    }

}
