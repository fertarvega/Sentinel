using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class EnemyMovement : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent navMesh;
    // Start is called before the first frame update
    void Awake()
    {
        navMesh = GetComponent<UnityEngine.AI.NavMeshAgent>();
        navMesh.stoppingDistance = 2.0f; // set stopping distance to 2 meter
    }

    // Update is called once per frame

    public void setDestination(Vector3 destination){
        navMesh.destination = destination;
    }

    public bool HasReachObjective(){
        return (!navMesh.pathPending && navMesh.remainingDistance <= navMesh.stoppingDistance);
    }

}
