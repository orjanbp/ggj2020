using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera mainCamera;

    private Limb heldLimb;
    private AttachPoint highlightedAttachPoint;
    private Limb highlightedLimb;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray inputRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(inputRay, out hit))
        {
            if (hit.collider.gameObject.layer == 8)
            {
                AttachPoint attachPoint = hit.collider.gameObject.GetComponent<AttachPoint>();
                if (attachPoint != null)
                {
                    if (highlightedAttachPoint != null)
                        highlightedAttachPoint.OnHighlightExit();
                    highlightedAttachPoint = attachPoint;
                    highlightedAttachPoint.OnHighlightStart();
                    Debug.Log("FOUND ATTACH POINT");
                }
            }
            else
            {
                if (highlightedAttachPoint != null)
                    highlightedAttachPoint.OnHighlightExit();
            }
            if (hit.collider.gameObject.layer == 9)
            {
                Limb limb = hit.collider.gameObject.GetComponent<Limb>();
                if (limb != null)
                {
                    highlightedLimb = limb;
                    Debug.Log("FOUND LIMB!");
                }
            }
            else
            {
                highlightedLimb = null;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (highlightedLimb != null)
                heldLimb = highlightedLimb;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (heldLimb != null)
                heldLimb = null;
        }
    }
}
