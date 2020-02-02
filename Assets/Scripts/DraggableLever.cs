using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableLever : Draggable
{

    public Rigidbody pivotRigidbody;
    public float triggerAngle = 170f;
    public float resetAngle = 20f;

    Coroutine resetRoutine;

    private void Start() {
        //currentAngle = minimumAngle;
        //pivotTransform.localEulerAngles = new Vector3(currentAngle, pivotTransform.localEulerAngles.y, pivotTransform.localEulerAngles.z);
    }

    public override void OnMoveStart() {
        if (resetRoutine != null) {
            StopCoroutine(resetRoutine);
            resetRoutine = null;
        }
    }

    public override void OnMoveInDirection(Vector2 direction) {
        if (resetRoutine != null) {
            return;
        }
        float torque = direction.y * 2f;
        pivotRigidbody.AddTorque(new Vector3(torque, 0f, 0f));
    }

    public void Reset() {
        resetRoutine = StartCoroutine(ResetRoutine());
    }

    IEnumerator ResetRoutine() {
        yield return new WaitForSeconds(1f);
        float timer = 0f;
        while (timer < 1f) {
            pivotRigidbody.AddTorque(new Vector3(99f, 0f, 0f));
            timer += Time.deltaTime;
            yield return null;
        }
        resetRoutine = null;
    }

}
