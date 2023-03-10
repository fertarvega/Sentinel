using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSystem : MonoBehaviour
{
    private int defenses;

    public void FinishTurn(){
        foreach(Unit unit in LevelGrid.Instance.unitList){
            if(unit.GetResourceTower() != null){
                unit.GetResourceTower().GetResourcesAmount();
            }
        }

        Debug.Log("Total gold: " + ResourceSystem.Instance.goldResource);
        Debug.Log("Total stone: " + ResourceSystem.Instance.stoneResource);
        Debug.Log("Total wood: " + ResourceSystem.Instance.woodResource);
        Debug.Log("Total crystal: " + ResourceSystem.Instance.crystalResource);
    }
}
