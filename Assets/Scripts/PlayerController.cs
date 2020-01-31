using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera mainCamera;
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
                    Debug.Log("FOUND ATTACH POINT");
                }
            }
        }
    }
}
