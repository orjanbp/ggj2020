using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveController : MonoBehaviour
{
    public Component LetterUI;
    protected string resultMessage;

    protected AttachPoint[] limbAttachPoints;

    protected string rightAnimal;
    protected int totalLimbs;

    protected int numLimbsRightAnimal;
    protected int numLimbsRightType;
    protected bool hasRightHead;

    private void Start()
    {
        Debug.Log("Good morning objectives!");
    }

    public void OnNewAnimal (Animal animal)
    {
        rightAnimal = animal.animal;
        limbAttachPoints = animal.GetComponentsInChildren<AttachPoint>();
        totalLimbs = limbAttachPoints.Length;

        Debug.Log("Got animal :: " + animal.animal);

        resetLimbCriterias();
        getLimbStatus(limbAttachPoints);
    }

    public void OnRedeemAnimal ()
    {
        resetLimbCriterias();
        getLimbStatus(limbAttachPoints);
        //writeResultLetter();
    }

    void resetLimbCriterias ()
    {
        numLimbsRightAnimal = 0;
        numLimbsRightType = 0;
        hasRightHead = false;
    }

    void getLimbStatus (AttachPoint[] anchorPoints)
    {
        string rightLimbType;
        Limb foundLimb;

        foreach(AttachPoint aPoint in anchorPoints)
        {
            rightLimbType = aPoint.GetComponent<AttachPoint>().limbType;
            foundLimb = aPoint.GetComponentInChildren<Limb>();

            if (!foundLimb)
            {
                Debug.Log("Missing:: " + rightAnimal + " " + rightLimbType);
            }
            else
            {
                Debug.Log("Found limb:: " + foundLimb.animal + " " + foundLimb.limbType
                    + ", expected:: " + rightAnimal + " " + rightLimbType);

                if (foundLimb.animal == rightAnimal) 
                    numLimbsRightAnimal++;

                if (foundLimb.limbType == rightLimbType) 
                    numLimbsRightType++;

                if (foundLimb.limbType == rightLimbType && foundLimb.limbType == "head" && foundLimb.animal == rightAnimal)
                    hasRightHead = true;
            }
        }
    }

    void writeResultLetter ()
    {
        resultMessage = "Checkup finished. ";
        resultMessage += "The animal was a " + rightAnimal + " ";
        resultMessage += "and " + numLimbsRightAnimal + " limbs were " + rightAnimal + " limbs.";
        resultMessage += "\n";
        resultMessage += numLimbsRightType + " limbs were in the right place.";

        LetterUI.GetComponent<Canvas>().enabled = true;
        LetterUI.GetComponentInChildren<UnityEngine.UI.Text>().text = resultMessage;
    }
}
