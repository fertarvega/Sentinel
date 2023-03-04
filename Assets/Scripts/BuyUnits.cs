using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyUnits : MonoBehaviour
{
    public List<GameObject> unitSelected = new List<GameObject>();

    public void BuyWizard(GameObject wizard){
        unitSelected = UnitSelections.Instance.GetListTowerSelected();
        foreach(GameObject unit in unitSelected){
            DefenseTower unitTower = unit.GetComponent<DefenseTower>();
            Debug.Log(unitTower.spotsList[0]);
            // Transform childTransform = unit.transform.GetChild(2);
            // Instantiate(wizard.transform, childTransform);
        }
    }
}
