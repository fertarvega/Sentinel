using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    public int damage = 0;
    public float range = 6f;
    public float attackInterval = 2f;

    private Enemy nearEnemy;
    private int attackReload;
    private float attackTimer;

    public ParticleSystem hability;
    
    [Header("Type of wizard")]
    [SerializeField] public string type;
    private bool attackEnabled = true;

    private void Start(){
        attackReload = 0;
        attackTimer = 0f;
    }

    private void Update(){
        if(attackEnabled){
            CheckEnemies();
            if (nearEnemy != null){
                attackTimer += Time.deltaTime;
                if (attackTimer >= attackInterval && attackReload == 0){
                    AttackEnemy(nearEnemy);
                    attackReload = Mathf.FloorToInt(attackInterval / Time.fixedDeltaTime);
                    attackTimer = 0f;
                }
                else if (attackReload > 0){
                    attackReload--;
                }
            }
        }
    }

    public void AttackEnemy(Enemy enemy){   
        enemy.Health.TakeDamage(damage);
        Vector3 enemyPosition = new Vector3(enemy.transform.position.x, enemy.transform.position.y + 0.5f, enemy.transform.position.z);
        ParticleSystem particles = Instantiate(hability, enemyPosition, Quaternion.identity);

        particles.Play();
    }

    public void CheckEnemies(){
        float minDistance = Mathf.Infinity;
        foreach (Enemy enemy in LevelGrid.Instance.enemyList){
            float distance = Vector3.Distance(transform.root.position, enemy.transform.position);
            if (distance < minDistance && distance <= range){
                nearEnemy = enemy;
                minDistance = distance;
            }
        }
        if (minDistance == Mathf.Infinity){
            nearEnemy = null;
        }
    }

    // public void CheckEnemies(){
    //     foreach (Enemy enemy in LevelGrid.Instance.enemyList){
    //         float distance = Vector3.Distance(transform.root.position, enemy.transform.position);
    //         if (distance <= range){
    //             nearEnemy = enemy;
    //             return;
    //         }
    //     }
    //     nearEnemy = null;
    // }

    public void DisableAttack(){
        attackEnabled = false;
    }
}
