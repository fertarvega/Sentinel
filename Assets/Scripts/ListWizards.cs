using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListWizards : MonoBehaviour
{

    [SerializeField] private List<Image> spotWizardImages = new List<Image>();
    [SerializeField] private List<Sprite> images = new List<Sprite>();

    private void Update(){
        
        int index = 0;

        // Get the parent DefenseTower component
        DefenseTower parentTower = GetComponentInParent<DefenseTower>();

        // Check if the parent has a spotsList
        if(parentTower != null && parentTower.spotsList.Count > 0){
            foreach(SpotWizard spot in parentTower.spotsList){
                Wizard wizard = spot.GetWizard();
                
                if(wizard != null){
                    if(wizard.type == "Water"){
                        spotWizardImages[index].sprite = images[0];
                    }
                    if(wizard.type == "Fire"){
                        spotWizardImages[index].sprite = images[1];
                    }
                    if(wizard.type == "Electro"){
                        spotWizardImages[index].sprite = images[2];
                    }
                    
                } 
                
                spotWizardImages[index].gameObject.SetActive(true);
                index++;
            }
        }
    }

    
   
}
