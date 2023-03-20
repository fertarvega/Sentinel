using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSystem : MonoBehaviour
{
    private DefenseTower defenseTowerSelected;
    private ResourceTower resourceTowerSelected;

    public int goldCost = 1;
    public int crystalCost = 1;

    public void BuyWizard(GameObject wizard){
        defenseTowerSelected = UnitSelections.Instance.GetDefenseTowerSelected();

        foreach(SpotWizard unitSpot in defenseTowerSelected.spotsList){
            if(
                ResourceSystem.Instance.goldResource < goldCost || 
                ResourceSystem.Instance.crystalResource < crystalCost
            ) {
                Debug.Log("limit reached, or resources are not enougth");
                break;
            }

            if(unitSpot.GetWizard() == null){
                ResourceSystem.Instance.goldResource -= goldCost;
                ResourceSystem.Instance.crystalResource -= crystalCost;
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
