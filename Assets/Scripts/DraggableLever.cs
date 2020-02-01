using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableLever : Draggable
{

    public Rigidbody pivotRigidbody;
    public float triggerAngle = 170f;
    public float resetAngle = 20f;
    bool hasTriggered = false;

    private void Start() {
        //currentAngle = minimumAngle;
        //pivotTransform.localEulerAngles = new Vector3(currentAngle, pivotTransform.localEulerAngles.y, pivotTransform.localEulerAngles.z);
    }

    public override void OnMoveInDirection(Vector2 direction) {

        float torque = direction.y * 2f;
        pivotRigidbody.AddTorque(new Vector3(torque, 0f, 0f));
        //Debug.Log("New angle " + newAngle);
        //if (newAngle > maximumAngle) {
        //    pivotTransform.localEulerAngles = new Vector3(maximumAngle, pivotTransform.localEulerAngles.y, pivotTransform.localEulerAngles.z);
        //    currentAngle = maximumAngle;
        //}
        //else if (newAngle < minimumAngle) {
        //    pivotTransform.localEulerAngles = new Vector3(minimumAngle, pivotTransform.localEulerAngles.y, pivotTransform.localEulerAngles.z);
        //    currentAngle = minimumAngle;
        //}
        //else {
        //    pivotTransform.localEulerAngles = new Vector3(newAngle, pivotTransform.localEulerAngles.y, pivotTransform.localEulerAngles.z);
        //    pivotTransform.RotateAround(pivotTransform.position, pivotTransform.right, currentAngle - newAngle);
        //    currentAngle = newAngle;
        //}
    }

}
