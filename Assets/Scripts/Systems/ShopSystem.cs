using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSystem : MonoBehaviour
{
    public static ShopSystem Instance { get; private set; }

    private DefenseTower defenseTowerSelected;
    private ResourceTower resourceTowerSelected;

    public int waterWizardGoldCost = 1;
    public int waterWizardCrystalCost = 1;

    public int defenseTowerGoldCost = 1;
    public int defenseTowerStoneCost = 1;
    public int defenseTowerWoodCost = 1;

    public int resourceTowerGoldCost = 1;
    public int resourceTowerStoneCost = 1;
    public int resourceTowerWoodCost = 1;
    public int resourceTowerCrystalCost = 1;

    public int spotTowerDefenseUpgradeGoldCost = 2;
    public int spotTowerDefenseUpgradeCrystalCost = 2;

    public int resourceTowerUpgradeGoldCost = 2;
    public int resourceTowerUpgradeWoodCost = 2;
    public int resourceTowerUpgradeStoneCost = 2;
    public int resourceTowerUpgradeCrystalCost = 1;

    private void Awake(){
        if (Instance != null)
        {
            Debug.LogError("There's more than one ShopSystem! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public bool CanBuyTowerDefense(){
            if(ResourceSystem.Instance.goldResource < defenseTowerGoldCost || ResourceSystem.Instance.stoneResource < defenseTowerStoneCost 
            || ResourceSystem.Instance.woodResource < defenseTowerWoodCost) {
                Debug.Log("limit reached, or resources are not enougth");
                return false;
            } else {
                return true;
            }
    }

    public void BuyTowerDefense(){
        ResourceSystem.Instance.goldResource -= defenseTowerGoldCost;
        ResourceSystem.Instance.stoneResource -= defenseTowerStoneCost;
        ResourceSystem.Instance.woodResource -= defenseTowerWoodCost;
    }

    public bool CanBuyResourceTower(){
        if(ResourceSystem.Instance.goldResource < resourceTowerGoldCost || ResourceSystem.Instance.stoneResource < resourceTowerStoneCost 
        || ResourceSystem.Instance.woodResource < resourceTowerWoodCost || ResourceSystem.Instance.crystalResource < resourceTowerCrystalCost ) {
            Debug.Log("limit reached, or resources are not enougth");
            return false;
        } else {
            return true;
        }
    }

    public void BuyResourceTower(){
        ResourceSystem.Instance.goldResource -= resourceTowerGoldCost;
        ResourceSystem.Instance.stoneResource -= resourceTowerStoneCost;
        ResourceSystem.Instance.woodResource -= resourceTowerWoodCost;
        ResourceSystem.Instance.crystalResource -= resourceTowerCrystalCost;
    }

    public void BuyWizard(GameObject wizard){
        defenseTowerSelected = UnitSelections.Instance.GetDefenseTowerSelected();

        foreach(SpotWizard unitSpot in defenseTowerSelected.spotsList){
            if(
                ResourceSystem.Instance.goldResource < waterWizardGoldCost || 
                ResourceSystem.Instance.crystalResource < waterWizardCrystalCost
            ) {
                Debug.Log("limit reached, or resources are not enougth");
                break;
            }

            if(unitSpot.GetWizard() == null){
                ResourceSystem.Instance.goldResource -= waterWizardGoldCost;
                ResourceSystem.Instance.crystalResource -= waterWizardCrystalCost;
                Transform addWizard = Instantiate(wizard.transform, unitSpot.transform);
                unitSpot.AddWizardToSpot(addWizard);
                defenseTowerSelected.ActivateCombinatedAttack();
                break;
            }
        }
    }

    public void BuySpotWizard(){
        if(ResourceSystem.Instance.goldResource < spotTowerDefenseUpgradeGoldCost || 
            ResourceSystem.Instance.crystalResource < spotTowerDefenseUpgradeCrystalCost) {
            Debug.Log("limit reached, or resources are not enougth");
        } else {
            defenseTowerSelected = UnitSelections.Instance.GetDefenseTowerSelected();

            SpotWizard spot = defenseTowerSelected.transform.Find("spot_2").GetComponent<SpotWizard>();

            defenseTowerSelected.spotsList.Add(spot);

            ResourceSystem.Instance.goldResource -= spotTowerDefenseUpgradeGoldCost;
            ResourceSystem.Instance.crystalResource -= spotTowerDefenseUpgradeCrystalCost;

            UnitSelections.Instance.ActivateShopSystemDefenseTower();
        }


    }

    public void BuyUpgradeResourceTower(){
        if(ResourceSystem.Instance.goldResource < resourceTowerUpgradeGoldCost || 
            ResourceSystem.Instance.woodResource < resourceTowerUpgradeWoodCost || 
            ResourceSystem.Instance.stoneResource < resourceTowerUpgradeStoneCost || 
            ResourceSystem.Instance.crystalResource < resourceTowerCrystalCost) {
            Debug.Log("limit reached, or resources are not enougth");
        } else {
            resourceTowerSelected = UnitSelections.Instance.GetResourceTowerSelected();

            resourceTowerSelected.getResourceQuantity = 2;

            ResourceSystem.Instance.goldResource -= resourceTowerUpgradeGoldCost;
            ResourceSystem.Instance.woodResource -= resourceTowerUpgradeWoodCost;
            ResourceSystem.Instance.stoneResource -= resourceTowerUpgradeStoneCost;
            ResourceSystem.Instance.crystalResource -= resourceTowerCrystalCost;

            UnitSelections.Instance.ActivateShopSystemResourceTower();
        }
    }
}
