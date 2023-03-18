using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyWizards : MonoBehaviour
{
    public Unit unitSelected;

    public void BuyWizard(GameObject wizard){
        unitSelected = UnitSelections.Instance.GetTowerSelected();
        // foreach(Unit unit in unitSelected){
            // if(unit != null){
                DefenseTower unitTower = unitSelected.GetComponent<DefenseTower>();
                // Transform childTransform = unitTower.transform.GetChild(2);
                foreach(SpotWizard unitSpot in unitTower.spotsList){
                    if(unitSpot.GetWizard() == null){
                        Transform addWizard = Instantiate(wizard.transform, unitSpot.transform);
                        unitSpot.AddWizardToSpot(addWizard);
                        break;
                    }
                }

            // }
        // }
    }
}
