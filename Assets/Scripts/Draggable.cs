using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MovableObject, IHightlightableObject
{
    public override void OnMoveStart()
    {
        Debug.Log("On drag start");
    }

    public override void OnMoveInDirection(Vector2 direction)
    {
        Debug.Log("Draggable DIRECTION X " + direction.x + " Y " + direction.y);       
    }

    public override void OnMoveStop()
    {
        Debug.Log("On Drag end");
    }

    public override void OnMoveSetPosition(Vector3 newPosition)
    {

    }

    public void HightlightStart()
    {

    }

    public void HightlightEnd()
    {

    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }

}
