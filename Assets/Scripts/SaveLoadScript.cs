using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveLoadScript : MonoBehaviour {
    Transform playerTransform;
    Transform cameraTransform;

    void Start() {
        var player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;
        var camera = GameObject.FindGameObjectWithTag("MainCamera");
        cameraTransform = camera.transform;
    }

    public void SaveScript(string saveName) {
        var bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + $"/{saveName}.dat");

        var currentTimespan = TimeSpan.FromSeconds(Time.realtimeSinceStartup);
        var data = new SaveData(
            positionX: playerTransform.position.x,
            positionY: playerTransform.position.y,
            positionZ: playerTransform.position.z,

            rotationX: cameraTransform.rotation.x,
            rotationY: playerTransform.rotation.y,

            playtimeHours: currentTimespan.Hours + CommonSceneData.PreviousPlaytime.Hours,
            playtimeMinutes: currentTimespan.Minutes + CommonSceneData.PreviousPlaytime.Minutes,
            playtimeSeconds: currentTimespan.Seconds + CommonSceneData.PreviousPlaytime.Seconds,

            sceneIndex: SceneManager.GetActiveScene().buildIndex
        );

        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Game data saved!");
    }

    public void LoadScript(string saveName) {
        if(File.Exists(Application.persistentDataPath + $"/{saveName}.dat")) {
            var bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + $"/{saveName}.dat", FileMode.Open);
            var data = (SaveData)bf.Deserialize(file);
            file.Close();

            playerTransform.position = new Vector3(data.PositionX, data.PositionY, data.PositionZ);

            cameraTransform.rotation = new Quaternion(data.RotationX, cameraTransform.rotation.y, cameraTransform.rotation.z, cameraTransform.rotation.w);
            playerTransform.rotation = new Quaternion(playerTransform.rotation.x, data.RotationY, playerTransform.rotation.z, playerTransform.rotation.w);

            CommonSceneData.PreviousPlaytime = new TimeSpan(data.PlaytimeHours, data.PlaytimeMinutes, data.PlaytimeSeconds);

            SceneManager.LoadScene(data.SceneIndex, LoadSceneMode.Single);

            Debug.Log("Game data loaded!");
        } else
            Debug.LogError("There is no save data!");
    }
}
