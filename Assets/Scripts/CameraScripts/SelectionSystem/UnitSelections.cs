using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitSelections : MonoBehaviour
{
    public List<GameObject> unitList = new List<GameObject>();
    public List<GameObject> unitSelected = new List<GameObject>();

    private static UnitSelections _instance;
    public static UnitSelections Instance { get { return _instance; } }

    public List<Button> buttonList = new List<Button>();

    void Awake() 
    {
        if(_instance != null && _instance != this) Destroy(this.gameObject);
        else _instance = this;
    }

    public void Update(){
        // print(unitSelected.Count);
        // if(unitSelected.Count == 0){
        //     foreach(Button button in buttonList){
        //         button.interactable = false;
        //     }
        // } else {
        //     foreach(Button button in buttonList){
        //         button.interactable = true;
        //     }
        // }
    }

    public void ClickSelect(GameObject unitToAdd)
    {
        DeselectAll();
        Select(unitToAdd);
    }
    
    public void ShiftClickSelect(GameObject unitToAdd)
    {
        if(!unitSelected.Contains(unitToAdd)) Select(unitToAdd);
        else Deselect(unitToAdd);
    }
    public void DragSelect(GameObject unitToAdd)
    {
        if(!unitSelected.Contains(unitToAdd)) Select(unitToAdd);
    }
    public void Select(GameObject unitToAdd)
    {
        unitSelected.Add(unitToAdd);
        unitToAdd.transform.GetChild(0).gameObject.SetActive(true);

    }
    public void Deselect(GameObject unitToDeselect)
    {
        unitSelected.Remove(unitToDeselect);
        unitToDeselect.transform.GetChild(0).gameObject.SetActive(false);
    }

    public void DeselectAll()
    {
        unitSelected.Clear();
        foreach( var unitToDeselect in unitList)
        {
            unitToDeselect.transform.GetChild(0).gameObject.SetActive(false);
        }

        // foreach( var unitToDeselect in unitList){
        //     for (int i = 0; i < unitToDeselect.transform.childCount; i++)
        //     {
        //         // Get the child game object at index i
        //         GameObject child = unitToDeselect.transform.GetChild(i).gameObject;

        //         // Do something with the child object
        //         Debug.Log(child.name);
        //     }
        // }
    }

}
