using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyMovement Movement;
    private EnemyAttack Attack;
    public HealthScript Health;
    public Transform target = null;

    private bool reachObjective = false;
    private int attackReload;
    private float attackTimer;
    public float attackInterval = 2f;

    private bool flagDebuff = false;
    private float timer = 0f;

    void Start(){
        Movement = GetComponent<EnemyMovement>();
        Attack = GetComponent<EnemyAttack>();
        Health = GetComponent<HealthScript>();
        LevelGrid.Instance.enemyList.Add(this);
    }

    void Update(){   
        if(target != null){
            Movement.setDestination(target.position);
            if(Movement.HasReachObjective() || reachObjective){
                attackTimer += Time.deltaTime;
                if (attackTimer >= attackInterval && attackReload == 0){
                    Attack.Attack(target);
                    attackReload = Mathf.FloorToInt(attackInterval / Time.fixedDeltaTime);
                    attackTimer = 0f;
                }
                else if (attackReload > 0){
                    attackReload--;
                }
            }            
        } else{
            Movement.setDestination(null);
        }

        if(flagDebuff){
            timer += Time.deltaTime;
            if(timer >= 2f){
                flagDebuff = false;
                timer = 0f;
                Movement.movementSpeed = 1.5f;
            }
        }
    }

    void OnDestroy(){
        LevelGrid.Instance.enemyList.Remove(this);
    }

    public void TakeDebuff(string debuff){
        flagDebuff = true;
        switch(debuff) {
            case "Stun":
                Movement.movementSpeed = 0f;
                break;
            case "Slow":
                Movement.movementSpeed = .5f;
                break;
            case "Burst":
                break;
        }
    }

    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.name == "CentralTower"){
            reachObjective = true;
        }
    }
}
