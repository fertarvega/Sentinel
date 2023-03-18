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
            DeactivateSpotWizardAttack();
            SelectHability();
            activateCombinatedAttack = true;
        }
    }

    private void DeactivateSpotWizardAttack(){
        foreach(SpotWizard spot in spotsList){
            spot.GetWizard().DisableAttack();
        }
    }

    private void SelectHability(){
        foreach(SpotWizard spot in spotsList){
            Wizard wizard = spot.GetWizard();
            wizardList.Add(wizard);
        }

        if((wizardList[0].type == "Electro" && wizardList[1].type == "Water") || (wizardList[0].type == "Water" && wizardList[1].type == "Electro")){
            hability = ListCombinedHabilities.Instance.listCombinedHabilities[1];
            damage = 1;
        } else {
            hability = ListCombinedHabilities.Instance.listCombinedHabilities[0];
            damage = 1;
        }
    }
}
