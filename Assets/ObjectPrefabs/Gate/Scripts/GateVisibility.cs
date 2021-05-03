using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateVisibility : MonoBehaviour
{
    [SerializeField]
    GateAnimated gate;

    void OnBecameVisible() {
        gate.CloseGate();
    }

    void OnBecameInvisible() {
        gate.OpenGate();
    }
}
