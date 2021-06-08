using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleporter : MonoBehaviour {
    bool playerIsOverlapping = false;

    public Transform player;
    public Transform reciever;

    // Update is called once per frame
    void Update() {
        if(!playerIsOverlapping)
            return;

        Vector3 portalToPlayer = player.position - transform.position;
        var dotProduct = Vector3.Dot(transform.up, portalToPlayer);
        if(dotProduct >= 0)
            return;
        float rotationDiff = reciever.eulerAngles.y - transform.eulerAngles.y;
        player.Rotate(Vector3.up, rotationDiff);

        Vector3 positionOffset = Quaternion.Euler(0, rotationDiff, 0) * portalToPlayer;
        player.position = reciever.position + positionOffset;

        playerIsOverlapping = false;
    }

    void OnTriggerEnter(Collider other) {
        if(other.tag == "Player")
            playerIsOverlapping = true;            
    }
    void OnTriggerExit(Collider other) {
        if(other.tag == "Player")
            playerIsOverlapping = false;
    }
}
