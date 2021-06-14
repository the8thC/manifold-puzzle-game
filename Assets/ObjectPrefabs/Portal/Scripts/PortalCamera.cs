using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour {
    Transform playerCamera;

    public FirstPersonMovement player;
    public Transform portal;
    public Transform otherPortal;

    void Start() {
        if(player == null)
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonMovement>();
        playerCamera = player.GetComponentInChildren<FirstPersonLook>().transform;
    }

    void Update() {
        float portalsAgnleDiff = Quaternion.Angle(portal.rotation, otherPortal.rotation);
        //portalsAgnleDiff += 180;
        Quaternion portalsRotationDiff = Quaternion.AngleAxis(portalsAgnleDiff, Vector3.up);
        var playerOffsetDelta = portalsRotationDiff * (playerCamera.transform.position - otherPortal.position);

        transform.position = portal.transform.position + playerOffsetDelta;

        Vector3 newCameraDirection = portalsRotationDiff * playerCamera.transform.forward;
        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
    }
}
