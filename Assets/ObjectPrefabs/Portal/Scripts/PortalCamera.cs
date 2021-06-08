using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour {
    Transform playerCamera;

    public FirstPersonMovement player;
    public Transform portal;
    public Transform otherPortal;

    void Start() {
        playerCamera = player.GetComponentInChildren<FirstPersonLook>().transform;
    }

    void Update() {
        float portalsAgnleDiff = Quaternion.Angle(portal.rotation, otherPortal.rotation);
        Quaternion portalsRotationDiff = Quaternion.AngleAxis(portalsAgnleDiff, Vector3.up);
        var playerOffsetDelta = portalsRotationDiff * (playerCamera.transform.position - otherPortal.position);

        transform.position = portal.transform.position + playerOffsetDelta;

        Vector3 newCameraDirection = portalsRotationDiff * playerCamera.transform.forward;
        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
    }
}
