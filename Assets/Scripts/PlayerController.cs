using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera mainCamera;

//    private Limb heldLimb;
//    private Draggable draggingDraggable;
    private MovableObject heldMovableObject;
    IHightlightableObject currentHightlightedObject;

    private AttachPoint highlightedAttachPoint;
    private Limb highlightedLimb;
    private Draggable highlightedDraggable;
    private Vector2 previousMousePosition;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray inputRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(inputRay.origin, inputRay.direction, Color.blue, 1f);
        RaycastHit hit;
        if (Physics.Raycast(inputRay, out hit))
        {
            if (hit.collider.gameObject.layer == 8 || hit.collider.gameObject.layer == 9 || hit.collider.gameObject.layer == 10)
            {

                IHightlightableObject highlightableObject = hit.collider.gameObject.GetComponent<IHightlightableObject>();
                if (highlightableObject != null)
                {
                    if (currentHightlightedObject != null)
                        currentHightlightedObject.HightlightEnd();
                    currentHightlightedObject = highlightableObject;
                    currentHightlightedObject.HightlightStart();
                    Debug.Log("FOUND ATTACH POINT");
                }
            }
            else
            {
                if (currentHightlightedObject != null)
                    currentHightlightedObject.HightlightEnd();
            }
        }
        else
        {
            if (currentHightlightedObject != null)
            {
                Debug.Log("Reset Highlighted");
                currentHightlightedObject.HightlightEnd();
                currentHightlightedObject = null;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            MovableObject moveableObject = currentHightlightedObject.GetGameObject().GetComponent<MovableObject>();
            if (moveableObject != null)
            {
                heldMovableObject = moveableObject;
                heldMovableObject.OnMoveStart();
            }
            
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (heldMovableObject != null)
            {
                heldMovableObject.OnMoveStop();
                heldMovableObject = null;
            }
        }
        else if (Input.GetMouseButton(0))
        {
            if (heldMovableObject != null)
            {
                //heldMovableObject.OnMoveInDirection(((Vector2)Input.mousePosition - previousMousePosition) * Time.deltaTime);
                Vector3 fromCameraToHeldObject = heldMovableObject.gameObject.transform.position - mainCamera.transform.position;
                heldMovableObject.OnMoveSetPosition(mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, fromCameraToHeldObject.z)));
            }
        }

        previousMousePosition = Input.mousePosition;
    }
}
