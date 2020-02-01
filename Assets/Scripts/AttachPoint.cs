using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachPoint : MonoBehaviour, IHightlightableObject
{
    public string limbType; // Identify type of limb
    public string animal;   // Type of animal, inherited from Animal

    Animal currentAnimalRef;
    Limb currentLimb;
    MeshRenderer m_Renderer;
    Collider localCollider;

    void Awake() {
        localCollider = GetComponent<Collider>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Hide attachment point on creation
        m_Renderer = GetComponent<MeshRenderer>();
        m_Renderer.enabled = false;

        animal = gameObject.GetComponentInParent<Animal>()?.animal;
        
    }

    public void SetAnimalRef(Animal newAnimalRef) {
        currentAnimalRef = newAnimalRef;
    }

    public void AttachLimb(Limb limb) {
        limb.transform.rotation = transform.rotation;
        limb.transform.position = transform.position;
        limb.transform.position -= limb.transform.TransformDirection(limb.anchorPointOffset);
        limb.GetComponent<Rigidbody>().useGravity = false;
        limb.GetComponent<Rigidbody>().isKinematic = true;
        limb.transform.parent = transform;
        limb.SetAttachPoint(this);
        currentLimb = limb;
        localCollider.enabled = false;
    }
    public void DetachLimb() {
        if (currentLimb != null) { 
            currentLimb.GetComponent<Rigidbody>().useGravity = true;
            currentLimb.GetComponent<Rigidbody>().isKinematic = false;
            currentLimb.transform.parent = null;
            currentLimb.SetAttachPoint(null);
            currentLimb = null;
            localCollider.enabled = true;
        }
    }

    public bool HasLimb() {
        return currentLimb != null;
    }

    public void HightlightStart()
    {
        if (!HasLimb())
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
