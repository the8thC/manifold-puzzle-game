using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerRotationUtils {
    public static Vector2 GetRotation(GameObject player) {
        Vector2 rotation = new Vector2();

        rotation.y = player.transform.rotation.eulerAngles.y;
        rotation.x = player.GetComponentInChildren<Camera>().transform.rotation.eulerAngles.x;
        return rotation;
    }

    public static void SetRotation(GameObject player, Vector2 rotation) {
        var playerModelRotation = player.transform.rotation;
        playerModelRotation.eulerAngles = new Vector3(playerModelRotation.eulerAngles.x, rotation.y, playerModelRotation.eulerAngles.z);
        player.transform.rotation = playerModelRotation;

        var camera = player.GetComponentInChildren<Camera>();
        var playerCameraRotation = camera.transform.rotation;
        playerModelRotation.eulerAngles = new Vector3(rotation.x, playerCameraRotation.eulerAngles.y, playerCameraRotation.eulerAngles.z);
        camera.transform.rotation = playerCameraRotation;
    }
}

