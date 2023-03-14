using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    public int damage = 0;
    public float range = 100f;
    public int towerHealth = 100;
    public float attackInterval = 2f;

    private Enemy nearEnemy;
    private int attackReload;
    private float attackTimer;

    public ParticleSystem hability;

    private void Start(){
        attackReload = 0;
        attackTimer = 0f;
    }

    private void FixedUpdate(){
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

    public void AttackEnemy(Enemy enemy){
        enemy.Health.TakeDamage(damage);

        ParticleSystem particles = Instantiate(hability, enemy.transform.position, Quaternion.identity);

        // Start playing the particle system
        particles.Play();

    
    }

    public void CheckEnemies(){
        foreach (Enemy enemy in LevelGrid.Instance.enemyList){
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance <= range){
                nearEnemy = enemy;
                return;
            }
        }
        nearEnemy = null;
    }
}
