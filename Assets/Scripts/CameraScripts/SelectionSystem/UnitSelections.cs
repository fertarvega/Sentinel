using System.Collections.Generic;
using UnityEngine;

public class UnitSelections : MonoBehaviour
{
    public List<GameObject> unitList = new List<GameObject>();
    public List<GameObject> unitSelected = new List<GameObject>();

    private static UnitSelections _instance;
    public static UnitSelections Instance { get { return _instance; } }

    void Awake() 
    {
        if(_instance != null && _instance != this) Destroy(this.gameObject);
        else _instance = this;
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
    }

}
