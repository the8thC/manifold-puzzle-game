using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMenu : MonoBehaviour
{
    public void NewGame() {
        CommonSceneData.PreviousPlaytime = new System.TimeSpan(0);
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
