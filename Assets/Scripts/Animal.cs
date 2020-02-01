using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public AttachPoint[] LimbCollection;
    public LimbManager m_LimbManager;

    public string animal;

    // Start is called before the first frame update
    void Start()
    {
        foreach (AttachPoint attPoint in LimbCollection)
        {
            var fetcher = m_LimbManager.FetchLimb(animal, attPoint.limbType);
            var attPos = attPoint.transform.position;
            var attRot = attPoint.transform.rotation;

            var newLimb = Instantiate(fetcher, attPos, attRot);
            newLimb.transform.position -= newLimb.transform.TransformDirection(newLimb.anchorPointOffset);
            //Debug.Log("ADDING NEW LIMB: " + attPoint + newLimb);
            //Debug.Log(newLimb.anchorPointOffset);|
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
