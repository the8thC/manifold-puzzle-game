using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoadScript : MonoBehaviour
{
    Transform trans;
    // Start is called before the first frame update
    void Start()
    {
        trans = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void SaveScript(Button button)
    {
        BinaryFormatter bf = new BinaryFormatter(); 
        FileStream file = File.Create(Application.persistentDataPath 
            + "/MySaveData" + button.name[button.name.Length - 1] + ".dat"); 
        SaveData.SaveData data = new SaveData.SaveData();

        data.saveName = DateTime.Now.ToString("yyyy-MM-dd");
        data.positionX = trans.position.x;
        data.positionY = trans.position.y;
        data.positionZ = trans.position.z;
        
        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Game data saved!");
    }

    public void LoadScript(Button button)
    {
        if (File.Exists(Application.persistentDataPath 
            + "/MySaveData" + button.name[button.name.Length - 1] + ".dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = 
            File.Open(Application.persistentDataPath 
            + "/MySaveData" + button.name[button.name.Length - 1] + ".dat", FileMode.Open);
            SaveData.SaveData data = (SaveData.SaveData)bf.Deserialize(file);
            file.Close();
            
            GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(data.positionX, data.positionY, data.positionZ);

            Debug.Log("Game data loaded!");
        }
        else
            Debug.LogError("There is no save data!");
    }
}
