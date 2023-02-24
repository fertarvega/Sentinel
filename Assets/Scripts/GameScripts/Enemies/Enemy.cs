using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int healt = 150;
    private Vector3 Origin; 
    public Transform Destiny = null;
    public bool yendo = true;
    private UnityEngine.AI.NavMeshAgent navMeshAgent;

    public Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = transform.GetComponent<UnityEngine.AI.NavMeshAgent>();
        Origin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {   
        // // Definimos una variable posicion para poder acceder a posicion desde EnemyScript
        // position = transform.position;
        // if(healt <= 0)
        // {
        //     navMeshAgent.SetDestination(transform.position);
        //     Destroy(gameObject,2);
        // }
        // else
        // {
            navMeshAgent.SetDestination(yendo ? Destiny.position : Origin);
        // }
    }

}
