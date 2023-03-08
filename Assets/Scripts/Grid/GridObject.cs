using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject
{
    private GridSystem gridSystem;
    private GridPosition gridPosition;
    public List<Unit> unitList;
    private List<UnitResource> resourceList;

    public GridObject(GridSystem gridSystem, GridPosition gridPosition){
        this.gridSystem = gridSystem;
        this.gridPosition = gridPosition;
        this.unitList = new List<Unit>();
        this.resourceList = new List<UnitResource>();
    }

    public override string ToString()
    {
        string unitString = "";

        // foreach(Unit unit in unitList){
        //     unitString += unit + "\n";
        // }
        return "[" + gridPosition.x + "," + gridPosition.z + "]" + "\n" + unitString; 
    }

    public void AddUnit(Unit unit){
        unitList.Add(unit);
    }

    public void RemoveUnit(Unit unit){
        unitList.Remove(unit);
    }

    public List<Unit> GetUnitList(){
        return unitList;
    }

    public bool HasAnyUnit(){
        return unitList.Count > 0;
    }

    public void AddUnitResource(UnitResource unitResource){
        resourceList.Add(unitResource);
    }

    public void RemoveUnitResource(UnitResource unitResource){
        resourceList.Remove(unitResource);
    }

    public List<UnitResource> GetUnitResourceList(){
        return resourceList;
    }

    public bool HasAnyUnitResource(){
        return resourceList.Count > 0;
    }
    
    public UnitResource GetUnitResource(){
        foreach(UnitResource unit in resourceList){
            return unit;
        }
        return null;
    }

}
