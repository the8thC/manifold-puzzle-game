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
        //Vector3 portalToPlayerYless = new Vector3(portalToPlayer.x, 0, portalToPlayer.z);
        //var yQuaternion = Quaternion.Euler(0, transform.eulerAngles.y, 0);
        //float dotProduct = Vector3.Dot(transform.TransformDirection(Vector3.forward), portalToPlayer);
        float dotProduct = Vector3.Dot(transform.forward, portalToPlayer);
        //float angleBetweenPortalUpAndPlayer = Vector3.Angle(portalToPlayer, transform.up);
        //if(player.eulerAngles.y - transform.eulerAngles.y > 0)
        //    return;
        //var dotLookAndUp = Vector3.Dot(transform.up, yQuaternion * transform.forward);
        if(dotProduct >= 0)
            return;
        //float rotationDiff = Quaternion.Angle(transform.rotation, reciever.rotation);
        float rotationDiff = reciever.eulerAngles.y - transform.eulerAngles.y;
        //rotationDiff += 180;
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
