using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    public PlayerTeleport destination;
    void OnTriggerEnter(Collider other) {
        if(destination == null || other.tag != "Player")
            return;
        var positionDiff = transform.position - other.transform.position;
        other.transform.position = destination.transform.position - positionDiff;
    }
}
