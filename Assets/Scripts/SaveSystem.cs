using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveData(){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/save-resources-map.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        List<UnitResource> data = new List<UnitResource>();
        data = LevelGrid.Instance.unitResourceList;

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void LoadData(){
        string path = Application.persistentDataPath + "/save-resources-map.fun";
        if(File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            List<UnitResource> data = formatter.Deserialize(stream) as List<UnitResource>;
            stream.Close();

            Debug.Log(data.Count);

            // LevelGrid.Instance.unitResourceList = data.unitResources;
        } else {
            Debug.LogError("Save file not found in " + path);
        }
    }
}
