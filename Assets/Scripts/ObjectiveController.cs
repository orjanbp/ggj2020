using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveController : MonoBehaviour
{
    public Component LetterUI;
    protected string resultMessage;
    protected GameStateController c_controller;

    protected AttachPoint[] limbAttachPoints;

    public string rightAnimal;
    public int totalLimbs;
    public int howManyLimbs = 0;
    public int howManyLimbsRightType = 0;
    public int howManyLimbsRightAnimal = 0;
    public bool hasHead = false;
    public bool hasRightHead = false;

    private void Start()
    {
        Debug.Log("Good morning objectives!");
        c_controller = GetComponent<GameStateController>();
    }

    public void OnNewAnimal (Animal animal)
    {
        rightAnimal = animal.animal;
        limbAttachPoints = animal.GetComponentsInChildren<AttachPoint>();
        totalLimbs = limbAttachPoints.Length;

        Debug.Log("Got animal :: " + animal.animal);

        getLimbStatus(limbAttachPoints);
    }

    public void OnUpdateAnimal (Animal animal)
    {
        if (limbAttachPoints == null) return;
        
        getLimbStatus(limbAttachPoints);
    }

    public void OnRedeemAnimal ()
    {
        getLimbStatus(limbAttachPoints);
        //writeResultLetter();
    }

    void resetTrackers ()
    {
        howManyLimbs = 0;
        howManyLimbsRightType = 0;
        howManyLimbsRightAnimal = 0;
        hasHead = false;
        hasRightHead = false;
    }

    void getLimbStatus (AttachPoint[] anchorPoints)
    {
        resetTrackers();

        foreach (AttachPoint aPoint in anchorPoints)
        {
            string rightLimbType = aPoint.GetComponent<AttachPoint>().limbType;
            Limb foundLimb = aPoint.GetComponentInChildren<Limb>();

            if (foundLimb)
            {
                howManyLimbs++;

                if (foundLimb.limbType == rightLimbType) 
                    howManyLimbsRightType++;

                if (foundLimb.animal == rightAnimal)
                    howManyLimbsRightAnimal++;

                if (foundLimb.limbType == rightLimbType && foundLimb.limbType == "head")
                {
                    hasHead = true;

                    if (foundLimb.animal == rightAnimal)
                        hasRightHead = true;
                }
            }
        }
        c_controller.UpdateAnimalState();
    }

    //void writeResultLetter ()
    //{
    //    resultMessage = "Checkup finished. ";
    //    resultMessage += "The animal was a " + rightAnimal + " ";
    //    resultMessage += "and " + numLimbsRightAnimal + " limbs were " + rightAnimal + " limbs.";
    //    resultMessage += "\n";
    //    resultMessage += numLimbsRightType + " limbs were in the right place.";

    //    LetterUI.GetComponent<Canvas>().enabled = true;
    //    LetterUI.GetComponentInChildren<UnityEngine.UI.Text>().text = resultMessage;
    //}
}
