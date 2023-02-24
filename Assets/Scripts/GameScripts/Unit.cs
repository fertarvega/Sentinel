using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private GridPosition gridPosition;
    private DefenseTower defenseTower;
    private ResourceTower resourceTower;

    private void Start(){
        UnitSelections.Instance.unitList.Add(this.gameObject);
        gridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        defenseTower = GetComponent<DefenseTower>();
        resourceTower = GetComponent<ResourceTower>();
    }

    private void OnDestroy() {
        UnitSelections.Instance.unitList.Remove(this.gameObject);
    }

    public GridPosition GetGridPosition(){
        return gridPosition;
    }
    // Here need to be the scripts depending on what kind of unit is
    public DefenseTower GetDefenseTower(){
        return defenseTower;
    }

    public ResourceTower GetResourceTower(){
        return resourceTower;
    }
}
