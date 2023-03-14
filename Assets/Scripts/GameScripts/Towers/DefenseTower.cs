using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseTower : MonoBehaviour
{
    // public int attack_ratio = 100;

    // public float damage = 0;

    // public int towerHealth = 100;

    // public float range = 100f;

    // public List<Enemy> Enemys;

    // private Enemy NearEnemy;
    // private int attack_reload;
    [SerializeField] public SpotWizard[] spotsList = new SpotWizard[3];

    // private void Start()
    // {
    //     attack_reload = attack_ratio;
    // }

    void Update()
    {
        // checkEnemys();
        // if(NearEnemy != null)
        // {
        //     AttackEnemy(NearEnemy);
        // }
        // if(attack_reload < attack_ratio){
        //     attack_reload++;
        // }
        // if(NearEnemy != null && attack_reload == attack_ratio){
        // }
        
    }

    // public void AttackEnemy(Enemy enemy)
    // {
    //     if(attack_reload == attack_ratio){
            
    //         enemy.Health.TakeDamage(damage);
    //     }
    //     else {
    //         attack_reload++;
    //     }
    // }

    // public void checkEnemys()
    // {
    //     foreach(Enemy enemy in Enemys)
    //     {
    //         float distance = Vector3.Distance(transform.position, enemy.transform.position);
    //         if(distance <= range){
    //             AttackEnemy(enemy);
    //         }
    //     }
    // }

}
