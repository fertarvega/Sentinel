using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemys : MonoBehaviour
{
    public GameObject enemyPrefab;

    public int enemyNumber = 10;

    private int enemyCounter = 0;

    public Transform target = null;

    private void Start()
    {
        InvokeRepeating("spawnEnemy", 0f, 1f); // spawn an enemy every 1 second
    }

    void spawnEnemy(){
        if(enemyCounter < enemyNumber){
            Vector3 newPosition = transform.position;
            // // random position
            // newPosition.x += Random.Range(-2.5f, 2.5f);
            // newPosition.z += Random.Range(-2.5f, 2.5f);


            GameObject enemy = Instantiate(enemyPrefab, newPosition, transform.rotation);
            enemy.GetComponent<Enemy>().target = target;
            enemyCounter++;
        }
        else
        {
            // stop the repeating invocation when we've spawned enough enemies
            CancelInvoke("SpawnEnemyWithDelay");
        }
    }
}
