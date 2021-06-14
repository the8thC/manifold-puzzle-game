using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitchScript : MonoBehaviour {
    void OnTriggerEnter(Collider other) {
        if(other.tag != "Player")
            return;
        //DontDestroyOnLoad(other);
        CommonSceneData.SwitchingLevels = true;
        CommonSceneData.PlayerRotation = PlayerRotationUtils.GetRotation(other.gameObject);
        var previousTimeScale = Time.timeScale;
        Time.timeScale = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
        Time.timeScale = previousTimeScale;
    }
}
