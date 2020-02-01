using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{

    public AttachPoint[] LimbCollection;
    public LimbManager m_LimbManager;

    // Start is called before the first frame update
    void Start()
    {
        foreach (AttachPoint point in LimbCollection)
        {
            var newLimb = m_LimbManager.GetRandomLimb();
            Debug.Log("ADDING NEW LIMB: " + point + newLimb);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
