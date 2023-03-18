using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSystem : MonoBehaviour
{
    private DefenseTower defenseTowerSelected;

    public void BuyWizard(GameObject wizard){
        defenseTowerSelected = UnitSelections.Instance.GetDefenseTowerSelected();

        foreach(SpotWizard unitSpot in defenseTowerSelected.spotsList){
            if(unitSpot.GetWizard() == null){
                Transform addWizard = Instantiate(wizard.transform, unitSpot.transform);
                unitSpot.AddWizardToSpot(addWizard);
                defenseTowerSelected.ActivateCombinatedAttack();
                break;
            }
        }
    }

    public void BuySpotWizard(){
        defenseTowerSelected = UnitSelections.Instance.GetDefenseTowerSelected();

        SpotWizard spot = defenseTowerSelected.transform.Find("spot_2").GetComponent<SpotWizard>();

        defenseTowerSelected.spotsList.Add(spot);

        UnitSelections.Instance.ActivateShopSystemDefenseTower();

    }
}
