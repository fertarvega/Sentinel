using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenesManager : MonoBehaviour
{
    public void ChangeFirstLevel(){
        SceneManager.LoadScene("MapScene");
    }

    public void QuitGame(){
        Application.Quit();
    }
}
