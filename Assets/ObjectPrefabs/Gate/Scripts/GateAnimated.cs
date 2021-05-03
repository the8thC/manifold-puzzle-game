using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateAnimated : MonoBehaviour
{
    Animator animator;

    void Awake() {
        animator = GetComponent<Animator>();
    }

    public void OpenGate() {
        animator.SetBool("Open", true);
    }

    public void CloseGate() {
        animator.SetBool("Open", false);
    }
}
