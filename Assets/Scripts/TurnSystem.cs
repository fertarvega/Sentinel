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

    [SerializeField] private TextMeshProUGUI txtGold;
    [SerializeField] private TextMeshProUGUI txtWood;
    [SerializeField] private TextMeshProUGUI txtStone;
    [SerializeField] private TextMeshProUGUI txtCrystal;
    [SerializeField] private TextMeshProUGUI txtRound;
    [SerializeField] private Button buttonFinishRound;

    private void Start(){
        buttonFinishRound.gameObject.SetActive(false);
    }

    private void Update(){
        if(LevelGrid.Instance.enemyList.Count == 0){
            buttonFinishRound.gameObject.SetActive(true);
        } else {
            buttonFinishRound.gameObject.SetActive(false);
        }
    }

    public void FinishTurn(){
        roundCount += 1;

        if(roundCount > totalRounds){
            buttonFinishRound.gameObject.SetActive(false);
        } else{
            foreach(Unit unit in LevelGrid.Instance.unitList){
                if(unit.GetResourceTower() != null){
                    unit.GetResourceTower().GetResourcesAmount();
                }
            }
            txtRound.text = "Round " + roundCount + "  of  " + totalRounds;
            txtGold.text = ResourceSystem.Instance.goldResource.ToString();
            txtWood.text = ResourceSystem.Instance.stoneResource.ToString();
            txtStone.text = ResourceSystem.Instance.woodResource.ToString();
            txtCrystal.text = ResourceSystem.Instance.crystalResource.ToString();
        }
    }
}
