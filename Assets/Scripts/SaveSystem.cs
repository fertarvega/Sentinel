using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public void LoadMap(){
        // string json = JsonUtility.ToJson(LevelGrid.Instance.gridSystem);
        // PlayerPrefs.SetString("MapData", json);

        // GridObject gridObject 

        LevelGrid.Instance.LoadMap();
    }
}
