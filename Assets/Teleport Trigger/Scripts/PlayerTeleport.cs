using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour {
    public PlayerTeleport destination;
    bool CheckAngles(Collider other) {
        var yAngle = other.transform.eulerAngles.y;
        if(yAngle >= -1 && yAngle <= 91)
            return true;
        if(yAngle >= -269 && yAngle <= -181)
            return true;
        return false;
    }
    void OnTriggerStay(Collider other) {
        if(destination == null || other.tag != "Player")
            return;
        if(!CheckAngles(other))
            return;
        var positionDiff = transform.position - other.transform.position;
        other.transform.position = destination.transform.position - positionDiff;
    }
}
