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

    void Awake(){
        if (Instance != null)
        {
            Debug.LogError("There's more than one UnitSelections! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void Update(){
        // print(unitSelected.Count);
        // if(unitSelected.Count == 0){
        //     foreach(GameObject button in buttonList){
        //         button.SetActive(false);

        //     }
        // } else 
    
    }

    public void ClickSelect(Unit unitToAdd){
        DeselectAll();
        Select(unitToAdd);
    }
    
    public void ShiftClickSelect(Unit unitToAdd){
        // if(!unitSelected.Contains(unitToAdd)) Select(unitToAdd);
        // else Deselect(unitToAdd);
    }
    public void DragSelect(Unit unitToAdd){
        // if(!unitSelected.Contains(unitToAdd)) Select(unitToAdd);
    }

    public void Select(Unit unitToAdd){
        // unitSelected.Add(unitToAdd);
        unitSelected = unitToAdd;
        if(unitToAdd.transform.GetChild(0).gameObject.activeSelf == false){
            unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
        }
        if(unitToAdd.GetDefenseTower() != null){
            flagTower = true;
        }
        ActivateButtonsDefenseTowerUI();
    }
    public void Deselect(Unit unitToDeselect){
        // unitSelected.Remove(unitToDeselect);
        unitSelected = null;
        unitToDeselect.transform.GetChild(0).gameObject.SetActive(false);
    }

    private void ActivateButtonsDefenseTowerUI(){
        if (unitSelected != null && flagTower) {
            DefenseTower defenseTower = unitSelected.GetDefenseTower();

            foreach(GameObject button in buttonList) {
                // Desactiva todos los botones por defecto
                button.SetActive(false);

                   if (button.name != "UpgradeTower") {
                        button.SetActive(true);
                    }
                if (!defenseTower.GetSecondSpot()) {
                    // Activa los botones que corresponden a torres que tienen la propiedad
                    if (button.name == "UpgradeTower") {
                        button.SetActive(true);
                    }
                } else {
                    // Activa otros botones si la torre no tiene la propiedad
                 
                }
            }
        } else {
            foreach(GameObject button in buttonList) {
                button.SetActive(false);
            }
        }
    }

    public void DeselectAll(){
        foreach(GameObject button in buttonList) {
                button.SetActive(false);
            }
        // unitSelected.Clear();
        flagTower = false;

        foreach( var unitToDeselect in LevelGrid.Instance.unitList)
        {
            unitToDeselect.transform.GetChild(0).gameObject.SetActive(false);
        }

        // foreach( var unitToDeselect in LevelGrid.Instance.unitList){
        //     for (int i = 0; i < unitToDeselect.transform.childCount; i++)
        //     {
        //         // Get the child game object at index i
        //         GameObject child = unitToDeselect.transform.GetChild(i).gameObject;

        //         // Do something with the child object
        //         Debug.Log(child.name);
        //     }
        // }
    }

    // public List<Unit> GetListTowerSelected(){
    //     return unitSelected;
    // }

    public Unit GetTowerSelected(){
        return unitSelected;
    }

    public void AddSpotWizard(){
        DefenseTower defenseTower = unitSelected.GetDefenseTower();

        SpotWizard spot = defenseTower.transform.Find("spot_2").GetComponent<SpotWizard>();

        defenseTower.spotsList[1] = spot;

        ActivateButtonsDefenseTowerUI();
    }
}
