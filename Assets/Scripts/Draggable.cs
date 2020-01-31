using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{

    public void OnDragStart()
    {
        Debug.Log("On drag start");
    }

    public void OnDragInDirection(Vector2 direction)
    {
        Debug.Log("Draggable DIRECTION " + direction);
    }

    public void OnDragStop()
    {
        Debug.Log("On Drag end");
    }

}
