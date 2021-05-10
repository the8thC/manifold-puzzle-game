using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoadScript : MonoBehaviour {
    Transform playerTransform;
    // Start is called before the first frame update
    void Start() {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void SaveScript(Button button) {
        var bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/MySaveData" + button.name[button.name.Length - 1] + ".dat");
        var data = new SaveData();

        data.saveName = DateTime.Now.ToString("yyyy-MM-dd");
        data.PositionX = playerTransform.position.x;
        data.PositionY = playerTransform.position.y;
        data.PositionZ = playerTransform.position.z;

        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Game data saved!");
    }

    public void LoadScript(Button button) {
        if(File.Exists(Application.persistentDataPath + "/MySaveData" + button.name[button.name.Length - 1] + ".dat")) {
            var bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/MySaveData" + button.name[button.name.Length - 1] + ".dat", FileMode.Open);
            var data = (SaveData)bf.Deserialize(file);
            file.Close();

            GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(data.PositionX, data.PositionY, data.PositionZ);

            Debug.Log("Game data loaded!");
        } else
            Debug.LogError("There is no save data!");
    }
}
