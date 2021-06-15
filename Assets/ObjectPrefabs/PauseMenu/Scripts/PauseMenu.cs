using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    public bool IsGamePaused = false;

    public List<GameObject> disableableObjects;

    void Start() {
        Time.timeScale = 1f;
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape))
            if(IsGamePaused)
                Resume();
            else
                Pause();
    }

    public void QuitGame() 
    {
        Time.timeScale = 1f;
        IsGamePaused = false;

        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void Resume() {
        foreach(var disableableObject in disableableObjects)
            disableableObject.SetActive(false);

        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;

        IsGamePaused = false;
    }

    void Pause() {
        foreach(var disableableObject in disableableObjects)
            disableableObject.SetActive(true);

        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        
        IsGamePaused = true;
    }
}
