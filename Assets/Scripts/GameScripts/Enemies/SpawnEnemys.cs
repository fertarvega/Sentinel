using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemys : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int numberOfEnemies = 10;
    public float spawnRadius = 10f;
    public Transform Destiny = null;
    void Awake()
    {
    }
    private void Start()
    {

        for (int i = 0; i < numberOfEnemies; i++)
        {
            Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
            
            spawnPosition.y = Terrain.activeTerrain.SampleHeight(spawnPosition);
            
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            
            enemy.GetComponent<Enemy>().Destiny = Destiny;
        }
    }
}
