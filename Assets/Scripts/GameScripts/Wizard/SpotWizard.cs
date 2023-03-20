using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotWizard : MonoBehaviour
{
    public Transform wizard;

    public void AddWizardToSpot(Transform wizard){
        this.wizard = wizard;
    }

    public Wizard GetWizard(){
        if(wizard == null){
            return null;
        } else {
            if (wizard.TryGetComponent<Wizard>(out Wizard wizardSelection))
            {
                return wizard.GetComponent<Wizard>();
            }
            else {
                return null;
            }
        }
    }
}
