using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachPoint : MonoBehaviour, IHightlightableObject
{
    // Identify type of limb
    public string limbType;

    // Type of animal, inherited from Animal
    public string animal;

    MeshRenderer m_Renderer;

    // Start is called before the first frame update
    void Start()
    {
        // Hide attachment point on creation
        m_Renderer = GetComponent<MeshRenderer>();
        m_Renderer.enabled = false;

        animal = gameObject.GetComponentInParent<Animal>().animal;
    }

    public void HightlightStart()
    {
        m_Renderer.enabled = true;
    }

    public void HightlightEnd()
    {
        m_Renderer.enabled = false;
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }
}
