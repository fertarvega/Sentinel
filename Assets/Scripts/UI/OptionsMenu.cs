using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private GameObject menuOptions;

    public void ActivateMenuOptions(){
        if(menuOptions.activeSelf){
            menuOptions.SetActive(false);
        } else {
            menuOptions.SetActive(true);
        }
    }
}
