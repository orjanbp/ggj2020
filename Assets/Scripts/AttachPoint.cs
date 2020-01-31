﻿using System.Collections;
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

    public void OnHighlightStart()
    {
        m_Renderer.enabled = true;
    }

    public void OnHighlightExit()
    {
        m_Renderer.enabled = false;
    }
}
