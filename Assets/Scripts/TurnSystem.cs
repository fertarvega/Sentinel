using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TurnSystem : MonoBehaviour
{
    private int defenses;
    public int roundCount = 1;
    public int totalRounds = 8;

    private void Start(){
        UiList.Instance.buttonFinishRound.gameObject.SetActive(false);
    }

    private void Update(){
        if(LevelGrid.Instance.enemyList.Count == 0){
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
            UiList.Instance.buttonFinishRound.gameObject.SetActive(false);
        } else{
            foreach(Unit unit in LevelGrid.Instance.unitList){
                if(unit.GetResourceTower() != null){
                    unit.GetResourceTower().GetResourcesAmount();
                }
            }
            UiList.Instance.txtRound.text = "Wave " + roundCount + "  of  " + totalRounds;
        }
    }

    public void StartTurn(){
        UiList.Instance.buttonStartWave.gameObject.SetActive(false);

    }
}
