using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Limb[] limbList;

    public Limb FetchLimb(string limbAnimal = "", string limbType = "")
    {
        // First get all limbs that have the right animal
        var limbsForAnimal = new List<Limb>();
        //Debug.Log("Getting limbs for " + limbAnimal);

        foreach (Limb limb in limbList)
        {
            if (limb.animal == limbAnimal)
            {
                limbsForAnimal.Add(limb);
                //Debug.Log("Adding limb ... " + limb.limbType + " for " + limb.animal);
            }
        }

        // Then N+1 all limbs of right type
        foreach (Limb limb in limbsForAnimal)
        {
            if (limb.limbType == limbType)
            {
                //Debug.Log("Returning limb ... " + limb.limbType);
                return limb;
            }
        }

        // Fallback
        var randLimb = limbList[Random.Range(0, limbList.Length)];
        //Debug.LogError("Fallback limb: " + randLimb.animal + " " + randLimb.limbType);
        return randLimb;
    }
}
