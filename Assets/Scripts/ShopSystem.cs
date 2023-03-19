using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSystem : MonoBehaviour
{
    private DefenseTower defenseTowerSelected;
    private ResourceTower resourceTowerSelected;

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

    public void BuyUpgradeResourceTower(){
        resourceTowerSelected = UnitSelections.Instance.GetResourceTowerSelected();

        resourceTowerSelected.getResourceQuantity = 2;

        UnitSelections.Instance.ActivateShopSystemResourceTower();
    }
}
