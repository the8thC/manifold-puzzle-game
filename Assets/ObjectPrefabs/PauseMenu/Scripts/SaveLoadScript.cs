using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveLoadScript : MonoBehaviour {
    GameObject player;
    Transform cameraTransform;

    void Start() {
        SetupPlayerAndCamera();
        if(CommonSceneData.LoadingGame) {
            player.transform.position = CommonSceneData.PlayerPosition;
            PlayerRotationUtils.SetRotation(player, CommonSceneData.PlayerRotation);
            CommonSceneData.LoadingGame = false;
        }
    }

    void SetupPlayerAndCamera() {
        if(player == null) {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        if(cameraTransform == null) {
            var camera = GameObject.FindGameObjectWithTag("MainCamera");
            cameraTransform = camera.transform;
        }
    }

    bool LoadScript(string saveName, bool switchScenes, out string loadedSaveName) {
        loadedSaveName = saveName;
        if(File.Exists(Application.persistentDataPath + $"/{saveName}.dat")) {
            var bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + $"/{saveName}.dat", FileMode.Open);
            SaveData data;
            try {
                data = (SaveData)bf.Deserialize(file);
            } finally {
                file.Close();
            }

            if(switchScenes) {
                SetupPlayerAndCamera();
                CommonSceneData.LoadingGame = true;
                CommonSceneData.PlayerPosition = new Vector3(data.PositionX, data.PositionY, data.PositionZ);
                CommonSceneData.PlayerRotation = new Vector2(data.RotationX, data.RotationY);
                CommonSceneData.PreviousPlaytime = new TimeSpan(data.PlaytimeHours, data.PlaytimeMinutes, data.PlaytimeSeconds);

                SceneManager.LoadScene(data.SceneIndex, LoadSceneMode.Single);
                Debug.Log("Game data loaded!");
            }

            loadedSaveName = $"Level: {data.SceneIndex}\nPlaytime: {data.PlaytimeHours}h:{data.PlaytimeMinutes}m:{data.PlaytimeSeconds}s";
            return true;
        }
        Debug.LogError("There is no save data!");
        return false;
    }

    internal bool LoadSaveData(string saveName, out string loadedSaveName) {
        return LoadScript(saveName, false, out loadedSaveName);
    }

    public void SaveScript(string saveName) {
        var bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + $"/{saveName}.dat");
        try {
            var currentTimespan = TimeSpan.FromSeconds(Time.realtimeSinceStartup);
            SetupPlayerAndCamera();
            var data = new SaveData(
                positionX: player.transform.position.x,
                positionY: player.transform.position.y,
                positionZ: player.transform.position.z,

                rotationX: cameraTransform.localRotation.eulerAngles.x,
                rotationY: player.transform.localRotation.eulerAngles.y,

                playtimeHours: currentTimespan.Hours + CommonSceneData.PreviousPlaytime.Hours,
                playtimeMinutes: currentTimespan.Minutes + CommonSceneData.PreviousPlaytime.Minutes,
                playtimeSeconds: currentTimespan.Seconds + CommonSceneData.PreviousPlaytime.Seconds,

                sceneIndex: SceneManager.GetActiveScene().buildIndex
            );

            bf.Serialize(file, data);
        } finally {
            file.Close();
        }

        Debug.Log("Game data saved!");
    }

    public void LoadScript(string saveName) {
        string trash;
        LoadScript(saveName, true, out trash);
    }
}
