using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private GridPosition gridPosition;
    private TowerScript tower;

    private void Start()
    {

        UnitSelections.Instance.unitList.Add(this.gameObject);
        gridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        LevelGrid.Instance.AddUnitAtGridPosition(gridPosition, this);
        tower = GetComponent<TowerScript>();
    }

    private void OnDestroy() {
        UnitSelections.Instance.unitList.Remove(this.gameObject);
    }

    public GridPosition GetGridPosition(){
        return gridPosition;
    }
    // Here need to be the scripts depending on what kind of unit is
    public TowerScript GetTower(){
        return tower;
    }
}
