using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TurnSystem : MonoBehaviour
{
    private int defenses;
    [SerializeField] private TextMeshProUGUI txtGold;
    [SerializeField] private TextMeshProUGUI txtWood;
    [SerializeField] private TextMeshProUGUI txtStone;
    [SerializeField] private TextMeshProUGUI txtCrystal;

    public void FinishTurn(){
        foreach(Unit unit in LevelGrid.Instance.unitList){
            if(unit.GetResourceTower() != null){
                unit.GetResourceTower().GetResourcesAmount();
            }
        }

        txtGold.text = ResourceSystem.Instance.goldResource.ToString();
        txtWood.text = ResourceSystem.Instance.stoneResource.ToString();
        txtStone.text = ResourceSystem.Instance.woodResource.ToString();
        txtCrystal.text = ResourceSystem.Instance.crystalResource.ToString();
    }
}
