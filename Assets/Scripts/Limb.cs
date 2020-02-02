
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limb : MovableObject, IHightlightableObject
{
    // Identify type and animal of limb
    public string limbType;
    public string animal;

    public AnimalType animalType;
    public LimbType limbType_;

    public Vector3 anchorPointOffset;

    public Renderer limbRenderer;
    public Material opaqueMat;
    public Material transpMat;

    private Rigidbody localRigidbody;
    private AttachPoint currentAttachPoint;
    // Start is called before the first frame update
    void Awake()
    {
        localRigidbody = GetComponent<Rigidbody>();
    }

    public void SetAttachPoint(AttachPoint attachPoint) {
        currentAttachPoint = attachPoint;
    }

    public override void OnMoveStart() {
        if (currentAttachPoint != null)
        {
            SoundEffects.PlayAudioAtLocation("detach", transform.position);
            currentAttachPoint.DetachLimb();
        }
        //localRigidbody.isKinematic = true;
        gameObject.layer = LayerMask.NameToLayer("HeldObject");
        Debug.Log("On drag start, set to layer " + LayerMask.LayerToName(gameObject.layer));
        transform.eulerAngles = Vector3.zero;

        if (limbRenderer != null)
        {
            limbRenderer.material = transpMat;
        }
    }

    public override void OnMoveInDirection(Vector2 direction)
    {
        //Debug.Log("Draggable DIRECTION X " + direction.x + " Y " + direction.y);
        //localRigidbody.MovePosition(localRigidbody.position + (Vector3)direction);
    }

    public override void OnMoveStop() {
        Debug.Log("On Drag end");
        //localRigidbody.isKinematic = false;
        gameObject.layer = LayerMask.NameToLayer("Limb");

        if (limbRenderer != null)
        {
            limbRenderer.material = opaqueMat;
        }
    }

    public override Vector3 GetMoveOffset() {
        return anchorPointOffset;
    }

    public override void OnMoveSetPosition(Vector3 newPosition)
    {
        localRigidbody.MovePosition(newPosition);
    }

    public void HightlightStart()
    {
        if(limbRenderer != null)
        {
            limbRenderer.material.SetFloat("_Highlighted", 1.0f);
        }
    }

    public void HightlightEnd()
    {
        if(limbRenderer != null)
        {
            limbRenderer.material.SetFloat("_Highlighted", 0.0f);
        }
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


public enum LimbType {
    Head,
    HindLeg,
    FrontLeg,
    Tail,
    Other
}
