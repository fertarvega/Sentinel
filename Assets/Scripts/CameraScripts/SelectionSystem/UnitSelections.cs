using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitSelections : MonoBehaviour
{
    public static UnitSelections Instance { get; private set; }
    // public List<Unit> unitSelected = new List<Unit>();
    public Unit unitSelected;
    public List<GameObject> buttonList = new List<GameObject>();

    private bool flagTower = false;

    private void Awake(){
        if (Instance != null){
            Debug.LogError("There's more than one UnitSelections! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void ClickSelect(Unit unitToAdd){
        DeselectAll();
        Select(unitToAdd);
    }
    
    public void Select(Unit unitToAdd){
        unitSelected = unitToAdd;
        if(unitToAdd.transform.GetChild(0).gameObject.activeSelf == false){
            unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
        }
        if(unitToAdd.GetDefenseTower() != null){
            flagTower = true;
        }
        ActivateShopSystemDefenseTower();
    }

    public void DeselectAll(){
        foreach(GameObject button in buttonList) {
                button.SetActive(false);
            }
        flagTower = false;

        foreach( var unitToDeselect in LevelGrid.Instance.unitList)
        {
            unitToDeselect.transform.GetChild(0).gameObject.SetActive(false);
        }
        unitSelected = null;
    }

    public DefenseTower GetDefenseTowerSelected(){
        return unitSelected.GetComponent<DefenseTower>();
    }

    public void ActivateShopSystemDefenseTower(){
        if (unitSelected != null && flagTower) {
            DefenseTower defenseTower = unitSelected.GetDefenseTower();

            foreach(GameObject button in buttonList) {
                button.SetActive(false);

                   if (button.name != "UpgradeTower") {
                        button.SetActive(true);
                    }
                if (defenseTower.GetLenghtSpotsList() == 1) {
                    if (button.name == "UpgradeTower") {
                        button.SetActive(true);
                    }
                } else {
                 
                }
            }
        } else {
            foreach(GameObject button in buttonList) {
                button.SetActive(false);
            }
        }
    }
}
