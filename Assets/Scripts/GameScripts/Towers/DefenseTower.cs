using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseTower : MonoBehaviour
{
    public int damage = 0;
    public float range = 6f;
    public int towerHealth = 100;
    public float attackInterval = 2f;

    private Enemy nearEnemy;
    private int attackReload;
    private float attackTimer;

    private ParticleSystem hability;

    [SerializeField] public List<SpotWizard> spotsList;

    private List<Wizard> wizardList = new List<Wizard>();

    private bool activateCombinatedAttack = false;

    private string debuff;

   private void Start(){
        attackReload = 0;
        attackTimer = 0f;
    }

    private void Update(){
        if(activateCombinatedAttack){
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

    public int GetLenghtSpotsList(){
        return spotsList.Count;
    }

    public void AttackEnemy(Enemy enemy){   
        enemy.Health.TakeDamage(damage);
        enemy.TakeDebuff(debuff);

        ParticleSystem particles = Instantiate(hability, enemy.transform.position, Quaternion.identity);

        particles.Play();
    }

    public void CheckEnemies(){
        foreach (Enemy enemy in LevelGrid.Instance.enemyList){
            float distance = Vector3.Distance(transform.root.position, enemy.transform.position);
            if (distance <= range){
                nearEnemy = enemy;
                return;
            }
        }
        nearEnemy = null;
    }

    public void ActivateCombinatedAttack(){
        bool bothSpotsHaveWizard = true;

        foreach(SpotWizard spot in spotsList){
            Wizard wizard = spot.GetWizard();
            
            if(wizard == null){
                bothSpotsHaveWizard = false;
                break;
            }
        }

        if(bothSpotsHaveWizard && spotsList.Count == 2){
            foreach(SpotWizard spot in spotsList){
                Wizard wizard = spot.GetWizard();
                wizardList.Add(wizard);
            }
            if(wizardList[0].type != wizardList[1].type){
                DeactivateSpotWizardAttack();
                SelectHability();
                activateCombinatedAttack = true;
            }
        }
    }

    private void DeactivateSpotWizardAttack(){
        foreach(SpotWizard spot in spotsList){
            spot.GetWizard().DisableAttack();
        }
    }

    private void SelectHability(){
        if((wizardList[0].type == "Water" && wizardList[1].type == "Fire") || (wizardList[0].type == "Fire" && wizardList[1].type == "Water")){
            hability = ListCombinedHabilities.Instance.listCombinedHabilities[0];
            attackInterval = 1f;
            damage = 15;
            debuff = "Stun";
        } else if((wizardList[0].type == "Water" && wizardList[1].type == "Electro") || (wizardList[0].type == "Electro" && wizardList[1].type == "Water")){
            hability = ListCombinedHabilities.Instance.listCombinedHabilities[1];
            attackInterval = 2f;
            damage = 25;
            debuff = "Slow";
        } else if((wizardList[0].type == "Fire" && wizardList[1].type == "Electro") || (wizardList[0].type == "Electro" && wizardList[1].type == "Fire")){
            hability = ListCombinedHabilities.Instance.listCombinedHabilities[2];
            attackInterval = 3f;
            damage = 50;
            debuff = "Burst";
        }
    }
}
