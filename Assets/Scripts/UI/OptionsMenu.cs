using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private GameObject menuOptions;

    public void ActivateAndDeactivateMenuOptions(){
        if(menuOptions.activeSelf){
            menuOptions.SetActive(false);
        } else {
            menuOptions.SetActive(true);
        }
    }

    public void ExitScene(){
        SceneManager.LoadScene("MainMenu");
    }
}
