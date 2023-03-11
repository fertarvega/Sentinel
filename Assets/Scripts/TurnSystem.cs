using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TurnSystem : MonoBehaviour
{
    private int defenses;
    public int rounds = 1;
    [SerializeField] private TextMeshProUGUI txtGold;
    [SerializeField] private TextMeshProUGUI txtWood;
    [SerializeField] private TextMeshProUGUI txtStone;
    [SerializeField] private TextMeshProUGUI txtCrystal;
    [SerializeField] private TextMeshProUGUI txtRound;

    public void FinishTurn(){
        foreach(Unit unit in LevelGrid.Instance.unitList){
            if(unit.GetResourceTower() != null){
                unit.GetResourceTower().GetResourcesAmount();
            }
        }

        rounds += 1;
        txtRound.text = "Round " + rounds + "  of 10";
        txtGold.text = ResourceSystem.Instance.goldResource.ToString();
        txtWood.text = ResourceSystem.Instance.stoneResource.ToString();
        txtStone.text = ResourceSystem.Instance.woodResource.ToString();
        txtCrystal.text = ResourceSystem.Instance.crystalResource.ToString();
    }
}
