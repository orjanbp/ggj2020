using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public AttachPoint[] attachPoints;
    public LimbManager m_LimbManager;

    public string animal;

    // Start is called before the first frame update
    void Start()
    {
        int firstMissingLimb = Random.Range(0, attachPoints.Length);
        for (int i = 0; i < attachPoints.Length; i++)
        {
            attachPoints[i].SetAnimalRef(this);
            if (i == firstMissingLimb || Random.value < 0.25f)
                continue;
            var limbPrefab = m_LimbManager.FetchLimb(animal, attachPoints[i].limbType);
            var attPos = attachPoints[i].transform.position;
            var attRot = attachPoints[i].transform.rotation;

            var newLimb = Instantiate(limbPrefab, attPos, attRot);
            attachPoints[i].AttachLimb(newLimb);
            //Debug.Log("ADDING NEW LIMB: " + attPoint + newLimb);
            //Debug.Log(newLimb.anchorPointOffset);|
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
