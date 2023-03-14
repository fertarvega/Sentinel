using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private GridPosition gridPosition;
    private DefenseTower defenseTower;
    private ResourceTower resourceTower;

    private void Start(){
        LevelGrid.Instance.unitList.Add(this);
        gridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        defenseTower = GetComponent<DefenseTower>();
        resourceTower = GetComponent<ResourceTower>();
    }

    private void OnDestroy() {
        LevelGrid.Instance.unitList.Remove(this);
    }

    public GridPosition GetGridPosition(){
        return gridPosition;
    }

    public DefenseTower GetDefenseTower(){
        return defenseTower;
    }

    public ResourceTower GetResourceTower(){
        return resourceTower;
    }
}
