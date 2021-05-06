using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {
    public static bool IsGamePaused = false;

    public List<GameObject> disableableObjects;

    // Update is called once per frame
    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape))
            if(IsGamePaused)
                Resume();
            else
                Pause();
    }

    public void QuitGame() {
        Application.Quit();
    }
    public void Resume() {
        foreach(var disableableObject in disableableObjects)
            disableableObject.SetActive(false);
        Time.timeScale = 1f;
        IsGamePaused = false;
    }
    void Pause() {
        foreach(var disableableObject in disableableObjects)
            disableableObject.SetActive(true);
        Time.timeScale = 0f;
        IsGamePaused = true;
    }
}
