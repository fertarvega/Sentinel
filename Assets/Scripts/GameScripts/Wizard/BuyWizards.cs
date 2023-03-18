using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyWizards : MonoBehaviour
{
    public List<Unit> unitSelected = new List<Unit>();

    public int goldCost = 1;

    public int crystalCost = 1;

    public void BuyWizard(GameObject wizard){
        unitSelected = UnitSelections.Instance.GetListTowerSelected();
        foreach(Unit unit in unitSelected){
            if(
                ResourceSystem.Instance.goldResource < goldCost || 
                ResourceSystem.Instance.crystalResource < crystalCost
            ) {
                Debug.Log("limit reached, or resources are not enougth");
                break;
            }

            DefenseTower unitTower = unit.GetComponent<DefenseTower>();
            // Transform childTransform = unitTower.transform.GetChild(2);
            foreach(SpotWizard unitSpot in unitTower.spotsList){

                Transform addWizard = Instantiate(wizard.transform, unitSpot.transform);
                ResourceSystem.Instance.goldResource -= goldCost;
                ResourceSystem.Instance.crystalResource -= crystalCost;
                unitSpot.AddWizardToSpot(addWizard);
                break;
            }
        }
    }
}
