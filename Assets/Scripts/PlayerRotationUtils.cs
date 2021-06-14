using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerRotationUtils {
    public static Vector2 GetRotation(GameObject player) {
        Vector2 rotation = new Vector2();

        rotation.y = player.transform.localRotation.eulerAngles.y;
        var camera = player.GetComponentInChildren<Camera>();
        rotation.x = camera.transform.localRotation.eulerAngles.x;
        return rotation;
    }

    public static void SetRotation(GameObject player, Vector2 rotation) {
        var playerModelRotation = player.transform.localRotation;
        playerModelRotation.eulerAngles = new Vector3(0, rotation.y, 0);
        player.transform.localRotation = playerModelRotation;

        var camera = player.GetComponentInChildren<Camera>();
        var playerCameraRotation = camera.transform.localRotation;
        playerCameraRotation.eulerAngles = new Vector3(rotation.x, 0, 0);
        camera.transform.localRotation = playerCameraRotation;
    }
}

