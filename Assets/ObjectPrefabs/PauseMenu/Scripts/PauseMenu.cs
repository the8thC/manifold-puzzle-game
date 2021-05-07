using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    public bool IsGamePaused = false;
    public bool PauseHasChanged = false;

    public List<GameObject> disableableObjects;

    // Update is called once per frame
    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape))
            if(IsGamePaused)
                Resume();
            else
                Pause();
    }

    public void QuitGame() 
    {
        Resume();
        SceneManager.LoadScene(0, LoadSceneMode.Single);
        //Resume();
    }

    public void Resume() {
        foreach(var disableableObject in disableableObjects)
            disableableObject.SetActive(false);
        Time.timeScale = 1f;
        if (IsGamePaused == true)
            PauseHasChanged = true;

        IsGamePaused = false;
    }

    void Pause() {
        foreach(var disableableObject in disableableObjects)
            disableableObject.SetActive(true);
        Time.timeScale = 0f;
        if (IsGamePaused == false)
            PauseHasChanged = true;

        IsGamePaused = true;
    }
}
