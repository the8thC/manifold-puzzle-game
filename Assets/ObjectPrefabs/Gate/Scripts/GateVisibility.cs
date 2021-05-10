using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateVisibility : MonoBehaviour {
    [SerializeField]
    GateAnimated gate;

    // void Update() {
    //     if (Physics.Raycast(cam.transform.position, gate.transform.position))
    //         gate.CloseGate();
    //     else
    //         gate.OpenGate();
    // }

    void OnBecameVisible() {
        gate.CloseGate();
    }

    void OnBecameInvisible() {
        gate.OpenGate();
    }
}
