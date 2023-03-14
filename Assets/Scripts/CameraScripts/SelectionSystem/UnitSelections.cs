using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitSelections : MonoBehaviour
{
    public List<Unit> unitSelected = new List<Unit>();

    private static UnitSelections _instance;
    public static UnitSelections Instance { get { return _instance; } }

    public List<GameObject> buttonList = new List<GameObject>();

    private bool flagTower = false;

    void Awake() 
    {
        if(_instance != null && _instance != this) Destroy(this.gameObject);
        else _instance = this;
    }

    public void Update(){
        // print(unitSelected.Count);
        if(unitSelected.Count == 0){
            foreach(GameObject button in buttonList){
                button.SetActive(false);

            }
        } else if (unitSelected.Count >= 1 && flagTower){
            foreach(GameObject button in buttonList){
                button.SetActive(true);
            }
        }
    }

    public void ClickSelect(Unit unitToAdd){
        DeselectAll();
        Select(unitToAdd);
    }
    
    public void ShiftClickSelect(Unit unitToAdd){
        if(!unitSelected.Contains(unitToAdd)) Select(unitToAdd);
        else Deselect(unitToAdd);
    }
    public void DragSelect(Unit unitToAdd){
        if(!unitSelected.Contains(unitToAdd)) Select(unitToAdd);
    }

    public void Select(Unit unitToAdd){
        unitSelected.Add(unitToAdd);
        unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
        if(unitToAdd.GetDefenseTower() != null){
            flagTower = true;
        }
    }
    public void Deselect(Unit unitToDeselect){
        unitSelected.Remove(unitToDeselect);
        unitToDeselect.transform.GetChild(0).gameObject.SetActive(false);
    }

    public void DeselectAll(){
        unitSelected.Clear();
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

    public List<Unit> GetListTowerSelected(){
        return unitSelected;
    }

}
