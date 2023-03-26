using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class TurnSystem : MonoBehaviour
{
    private int defenses;
    public int roundCount = 1;
    public int totalRounds = 8;
    [SerializeField] List<SpawnEnemys> spawnEnemys = new List<SpawnEnemys>();

    private void Start(){
        UiList.Instance.buttonFinishRound.gameObject.SetActive(false);
        UiList.Instance.buttonStartWave.gameObject.SetActive(true);
        UiList.Instance.txtRound.text = "Wave " + roundCount + "  of  " + totalRounds;
    }

    private void Update(){
        if(LevelGrid.Instance.enemyList.Count == 0 && !UiList.Instance.buttonStartWave.IsActive()){
            UiList.Instance.buttonFinishRound.gameObject.SetActive(true);
        } else {
            UiList.Instance.buttonFinishRound.gameObject.SetActive(false);
        }
    }

    public void FinishTurn(){
        roundCount += 1;
        UiList.Instance.buttonFinishRound.gameObject.SetActive(false);
        UiList.Instance.buttonStartWave.gameObject.SetActive(true);

        if(roundCount > totalRounds){
            // UiList.Instance.buttonFinishRound.gameObject.SetActive(false);
            var scene = SceneManager.GetActiveScene().name;
            if(scene == "Level_1"){
                SceneManager.LoadScene("MainMenu");
            }
        } else{
            foreach(Unit unit in LevelGrid.Instance.unitList){
                if(unit.GetResourceTower() != null){
                    unit.GetResourceTower().GetResourcesAmount();
                }
            }
            
            GetDefaultResources();
            UiList.Instance.txtRound.text = "Wave " + roundCount + "  of  " + totalRounds;
        }
    }

    public void StartTurn(){
        foreach(SpawnEnemys spawn in spawnEnemys){
            spawn.enemyNumber += 1;
            spawn.StartSpawnEnemy();
        }
        UiList.Instance.buttonStartWave.gameObject.SetActive(false);
    }


    public void GetDefaultResources(){
        ResourceSystem.Instance.goldResource += 1;
        ResourceSystem.Instance.stoneResource += 1;
        ResourceSystem.Instance.woodResource += 1;
        ResourceSystem.Instance.crystalResource += 1;
    }
}
