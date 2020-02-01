using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LeverTriggerBox : MonoBehaviour
{

    public UnityEvent eventOnTrigger;

    void OnTriggerEnter(Collider collider) {
        Debug.Log("On trigger enter collider: " + collider.attachedRigidbody.gameObject.tag);
        if (collider.attachedRigidbody?.gameObject.tag == "LeverHandle") {
            eventOnTrigger.Invoke();
        }
    }
}
