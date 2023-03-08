using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyUnits : MonoBehaviour
{
    public List<Unit> unitSelected = new List<Unit>();

    public void BuyWizard(GameObject wizard){
        unitSelected = UnitSelections.Instance.GetListTowerSelected();
        foreach(Unit unit in unitSelected){
            if(unit != null){
                DefenseTower unitTower = unit.GetComponent<DefenseTower>();
                // Transform childTransform = unitTower.transform.GetChild(2);
                foreach(SpotWizard unitSpot in unitTower.spotsList){
                    if(unitSpot.GetWizard() == null){
                        Transform addWizard = Instantiate(wizard.transform, unitSpot.transform);
                        unitSpot.AddWizardToSpot(addWizard);
                        break;
                    }
                }

            }
        }
    }
}
