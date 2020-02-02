using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    public virtual string getObjectiveText()
    {
        return "There is no objective.";
    }
    
    public virtual bool checkObjectiveCriteria()
    {
        Debug.Log("There are no criterias.");
        return false;
    }
}
