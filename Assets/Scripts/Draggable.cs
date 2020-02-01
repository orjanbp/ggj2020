﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MovableObject
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

}
