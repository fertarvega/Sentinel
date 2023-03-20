using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyMovement Movement;

    private EnemyAttack Attack;

    public HealthScript Health;

    public Transform target = null;

    void Start(){
        Movement = GetComponent<EnemyMovement>();
        Attack = GetComponent<EnemyAttack>();
        Health = GetComponent<HealthScript>();
        LevelGrid.Instance.enemyList.Add(this);
    }


    void Update(){   
        if(target != null){
            Movement.setDestination(target.position);
            if(Movement.HasReachObjective()){
                Attack.Attack(target);
            }
        }else{
            Movement.setDestination(null);
        }
    }

    void OnDestroy(){
        LevelGrid.Instance.enemyList.Remove(this);
    }

    public void TakeDebuff(string debuff){
        switch(debuff) {
            case "Stun":
                break;
            case "Slow":
                break;
            case "Burst":
                break;
        }
    }
}
