using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbManager : MonoBehaviour
{
    // Start is called before the first frame update

    public Limb[] LimbList;

    public Limb GetRandomLimb()
    {
        var randLimb = LimbList[Random.Range(0, LimbList.Length)];
        Debug.Log("Random limb: " + randLimb);
        return randLimb;
    }

    //public Limb GetRandomHead()
    //{
    //    var randHead = new Limb(); // TODO: Fetch head
    //    return randHead;
    //}
}
