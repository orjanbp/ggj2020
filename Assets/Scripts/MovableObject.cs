using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : MonoBehaviour
{
    public virtual void OnMoveStart()
    {
        Debug.Log("On drag start");
    }

    public virtual void OnMoveInDirection(Vector2 direction)
    {
        Debug.Log("Draggable DIRECTION X " + direction.x + " Y " + direction.y);
    }

    public virtual void OnMoveStop()
    {
        Debug.Log("On Drag end");
    }
}
