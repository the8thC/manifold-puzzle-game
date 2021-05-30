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
        var playerAndPortalAngleDiff = Quaternion.Angle(otherPortal.rotation, player.transform.rotation) + portalsAgnleDiff;
        var playerOffsetDelta = (playerCamera.transform.position - otherPortal.position);

        transform.position = portal.position - (Quaternion.AngleAxis(playerAndPortalAngleDiff, Vector3.up) * playerOffsetDelta).normalized * playerOffsetDelta.magnitude;

        Quaternion portalsRotationDiff = Quaternion.AngleAxis(portalsAgnleDiff, Vector3.up);
        Vector3 newCameraDirection = portalsRotationDiff * playerCamera.transform.forward;
        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
    }
}
