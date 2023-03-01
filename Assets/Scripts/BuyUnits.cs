using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyUnits : MonoBehaviour
{
    public List<GameObject> unitSelected = new List<GameObject>();

    public void BuyWizard(GameObject wizard){
        unitSelected = UnitSelections.Instance.unitSelected;
        foreach(GameObject unit in unitSelected){
            Transform childTransform = unit.transform.GetChild(2);
            Instantiate(wizard.transform, childTransform);
        }
    }
}
