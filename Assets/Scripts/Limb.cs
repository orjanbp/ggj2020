﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limb : MovableObject, IHightlightableObject
{
    // Identify type and animal of limb
    public string limbType;
    public string animal;

    public Vector3 anchorPointOffset;
    private Rigidbody localRigidbody;
    // Start is called before the first frame update
    void Awake()
    {
        localRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void OnMoveStart()
    {
        Debug.Log("On drag start");
        localRigidbody.isKinematic = true;
        gameObject.layer = 11;
    }

    public override void OnMoveInDirection(Vector2 direction)
    {
        Debug.Log("Draggable DIRECTION X " + direction.x + " Y " + direction.y);
        localRigidbody.MovePosition(localRigidbody.position + (Vector3)direction);
    }

    public override void OnMoveStop()
    {
        Debug.Log("On Drag end");
        localRigidbody.isKinematic = false;
        gameObject.layer = 9;
    }

    public override void OnMoveSetPosition(Vector3 newPosition)
    {
        localRigidbody.MovePosition(newPosition);
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

#if UNITY_EDITOR
    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = new Color(1, 1, 0, 0.75F);
        Vector3 anchorRealWorld = transform.position + anchorPointOffset;
        Gizmos.DrawRay(anchorRealWorld, transform.right);
    }
    #endif
}
