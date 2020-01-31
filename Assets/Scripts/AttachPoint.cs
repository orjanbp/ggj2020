using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachPoint : MonoBehaviour
{

    public string LimbName;

    MeshRenderer m_Renderer;

    // Start is called before the first frame update
    void Start()
    {
        m_Renderer = GetComponent<MeshRenderer>();
        m_Renderer.enabled = false; // Should we hide the mesh renderer on creation?
    }

    void OnMouseOver()
    {
        Debug.Log("MOUSE EVENT");
        m_Renderer.enabled = true;
    }

    void OnMouseExit()
    {
        m_Renderer.enabled = false;
    }
}
