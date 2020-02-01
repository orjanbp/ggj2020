using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : Draggable, IHightlightableObject
{
    public float torque = 0.3f;
    public float inertia = 0.8f;

    Rigidbody rb;
    Vector3 m_rotateVelocity;
    bool isDragged = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public override void OnMoveStart()
    {
        base.OnMoveStart(); // Prob do not need
        isDragged = true;
    }

    public override void OnMoveStop()
    {
        base.OnMoveStop(); // Prob do not need
        isDragged = false;
    }

    public override void OnMoveInDirection (Vector2 direction)
    {
        m_rotateVelocity = new Vector3(0, -direction.x, 0);
        //Debug.Log("Draggable DIRECTION X " + -direction.x + " Y " + direction.y);
    }

    void FixedUpdate()
    {
        if (!isDragged) m_rotateVelocity = m_rotateVelocity * inertia;

        Quaternion deltaRotation = Quaternion.Euler(m_rotateVelocity * torque);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}
