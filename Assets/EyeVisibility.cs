using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeVisibility : MonoBehaviour
{
    [SerializeField]
    GateAnimated gate;

    void OnBecameVisible() {
        gate.OpenGate();
    }

    void OnBecameInvisible() {
        gate.CloseGate();
    }
}
