using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class SaveData {
    #region Player Transform
    public float PositionX { get; private set; }
    public float PositionY { get; private set; }
    public float PositionZ { get; private set; }
    public float RotationX { get; private set; }
    public float RotationY { get; private set; }
    #endregion

    #region PlayTime
    public int PlaytimeHours { get; private set; }
    public int PlaytimeMinutes { get; private set; }
    public int PlaytimeSeconds { get; private set; }
    #endregion

    #region Scene Data
    public int SceneIndex { get; private set; }
    #endregion

    public SaveData(float positionX, float positionY, float positionZ, float rotationX, float rotationY, int playtimeHours, int playtimeMinutes, int playtimeSeconds, int sceneIndex) {
        PositionX = positionX;
        PositionY = positionY;
        PositionZ = positionZ;
        RotationX = rotationX;
        RotationY = rotationY;

        PlaytimeHours = playtimeHours;
        PlaytimeMinutes = playtimeMinutes;
        PlaytimeSeconds = playtimeSeconds;

        SceneIndex = sceneIndex;
    }
}