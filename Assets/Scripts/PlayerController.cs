using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera mainCamera;
    public Rigidbody playerRigidbody;
    public HingeJoint playerHingeJoint;

//    private Limb heldLimb;
//    private Draggable draggingDraggable;
    private MovableObject heldMovableObject;
    IHightlightableObject currentHightlightedObject;
    
    private Vector2 previousMousePosition;
    private const float zOffsetFromCamera = 4f;
    int allRaycastLayers = 0;
    int holdingLimbRaycastLayers = 0;
    // Start is called before the first frame update
    void Start()
    {
        allRaycastLayers = LayerMask.GetMask("AttachPoint", "Limb", "Draggable");
        holdingLimbRaycastLayers = LayerMask.GetMask("AttachPoint");
    }

    // Update is called once per frame
    void Update()
    {
        int currentLayerMask = allRaycastLayers;
        if (heldMovableObject != null && heldMovableObject is Limb) {
            //Debug.Log("USING holdingLimbRaycastLayers");
            currentLayerMask = holdingLimbRaycastLayers;
        }

        bool shouldRaycast = true;
        if (heldMovableObject != null && heldMovableObject is Draggable) {
            shouldRaycast = false;
        }

        Ray inputRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(inputRay.origin, inputRay.direction, Color.blue, 1f);
        RaycastHit hit;
        if (shouldRaycast && Physics.Raycast(inputRay, out hit, 40, currentLayerMask))
        {
            if (hit.collider.gameObject.layer == 8 || hit.collider.gameObject.layer == 9 || hit.collider.gameObject.layer == 10)
            {
                IHightlightableObject highlightableObject = hit.collider.gameObject.GetComponent<IHightlightableObject>();
                if (highlightableObject != null && highlightableObject != currentHightlightedObject) {
                    if (currentHightlightedObject != null)
                        currentHightlightedObject.HightlightEnd();
                    currentHightlightedObject = highlightableObject;
                    currentHightlightedObject.HightlightStart();
                }
            }
            else
            {
                if (currentHightlightedObject != null) {
                    currentHightlightedObject.HightlightEnd();
                    currentHightlightedObject = null;
                }
            }
        }
        else
        {
            if (currentHightlightedObject != null)
            {
                currentHightlightedObject.HightlightEnd();
                currentHightlightedObject = null;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (currentHightlightedObject != null) {
                MovableObject moveableObject = currentHightlightedObject.GetGameObject().GetComponent<MovableObject>();
                if (moveableObject != null) {
                    heldMovableObject = moveableObject;
                    heldMovableObject.OnMoveStart();
                    //currentZOffsetFromCamera = (heldMovableObject.gameObject.transform.position - mainCamera.transform.position).z;
                    playerRigidbody.MovePosition(heldMovableObject.transform.position);
                    //Limb move offset is from -1 to 1 in localspace. Turn it into normal -0.5 to 0.5 to use it as an anchor
                    playerHingeJoint.connectedAnchor = heldMovableObject.GetMoveOffset() * 0.5f; //heldMovableObject.transform.
                    playerHingeJoint.connectedBody = heldMovableObject.GetComponent<Rigidbody>();
                }
            }
            
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (heldMovableObject != null)
            {
                playerHingeJoint.connectedBody = null;
                heldMovableObject.OnMoveStop();
                if (currentHightlightedObject != null && currentHightlightedObject is AttachPoint && heldMovableObject is Limb) {
                    (currentHightlightedObject as AttachPoint).AttachLimb(heldMovableObject as Limb);
                }
                heldMovableObject = null;
            }
        }
        else if (Input.GetMouseButton(0))
        {
            if (heldMovableObject != null)
            {
                if (heldMovableObject is Limb) {
                    //heldMovableObject.OnMoveInDirection(((Vector2)Input.mousePosition - previousMousePosition) * Time.deltaTime);
                    //currentZOffsetFromCamera = (heldMovableObject.gameObject.transform.position - mainCamera.transform.position).z;
                    playerRigidbody.MovePosition(mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, zOffsetFromCamera)));
                }
                else if (heldMovableObject is Draggable) {
                    heldMovableObject.OnMoveInDirection((Vector2)Input.mousePosition - previousMousePosition);
                }
            }
        }

        previousMousePosition = Input.mousePosition;
    }
}
