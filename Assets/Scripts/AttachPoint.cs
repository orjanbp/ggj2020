using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachPoint : MonoBehaviour, IHightlightableObject
{
    public string limbType; // Identify type of limb
    public string animal;   // Type of animal, inherited from Animal

    public AnimalType animalType;
    public LimbType limbType_;

    public AnimationCurve attachAnimation;
    public AnimationCurve idleAnimation;

    float neutralXRotation;
    Animal currentAnimalRef;
    Limb currentLimb;
    MeshRenderer m_Renderer;
    Collider localCollider;

    void Awake() {
        localCollider = GetComponent<Collider>();
        neutralXRotation = transform.eulerAngles.x;
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

        //Special for weird heads
        if (limbType_ != LimbType.Head && limb.limbType_ == LimbType.Head) {
            limb.transform.localPosition = Vector3.zero;
            if (limbType_ != LimbType.HindLeg)
                limb.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
        }

        limb.SetAttachPoint(this);
        currentLimb = limb;
        localCollider.enabled = false;

        StartCoroutine(AnimateLimb(attachAnimation));
        // tell the parent what has happened
        if (currentAnimalRef) currentAnimalRef.OnChangeLimbs();
    }
    public void DetachLimb() {
        if (currentLimb != null) { 
            currentLimb.GetComponent<Rigidbody>().useGravity = true;
            currentLimb.GetComponent<Rigidbody>().isKinematic = false;
            currentLimb.transform.parent = null;
            currentLimb.SetAttachPoint(null);
            currentLimb = null;
            localCollider.enabled = true;

            // tell the parent what has happened
            if (currentAnimalRef) currentAnimalRef.OnChangeLimbs();
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

    IEnumerator AnimateLimb(AnimationCurve animationCurve) {
        Debug.Log("WIll start animating");
        float secondsLength = animationCurve.length;
        float startTime = Time.time;
        while (Time.time - startTime < secondsLength) {
            transform.eulerAngles = new Vector3(neutralXRotation + animationCurve.Evaluate(Time.time - startTime) * 45f, transform.eulerAngles.y, transform.eulerAngles.z);
            Debug.Log("Got angle " + (neutralXRotation + animationCurve.Evaluate(Time.time - startTime) * 45f) + " from curve evaluation " + animationCurve.Evaluate(Time.time - startTime));
            yield return null;
        }
    }
}
