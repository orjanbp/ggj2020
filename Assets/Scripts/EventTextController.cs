using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EventTextController : MonoBehaviour
{
    public RectTransform spawnAnimalText;
    public TextMeshProUGUI animalText;
    
    public RectTransform spawnCorner;
    public TextMeshProUGUI cornerText;

    public TextMeshProUGUI ObjectiveLimbs;
    public TextMeshProUGUI ObjectiveLimbTypes;
    public TextMeshProUGUI ObjectiveHead;

    private void Start()
    {
        ObjectiveLimbs.text = "";
        ObjectiveLimbTypes.text = "";
        ObjectiveHead.text = "";
    }

    public void SpawnAnimalText (string animalName)
    {
        Component flyingText = Instantiate(animalText, spawnAnimalText.position, spawnAnimalText.rotation, spawnAnimalText.parent);
        flyingText.GetComponent<TextMeshProUGUI>().text = "Holy crap, it's a " + animalName + "!";
    }

    public void SpawnCornerText(string textInput)
    {
        Component flyingText = Instantiate(cornerText, spawnCorner.position, spawnCorner.rotation, spawnCorner.parent);
        flyingText.GetComponent<TextMeshProUGUI>().text = textInput;
    }

    public void updateLimbAnimalText (string animalName, int rightLimbs, int allLimbs)
    {
        string newText;

        newText = "There's " + rightLimbs + " out of " + allLimbs + " limbs.";

        if (rightLimbs == allLimbs)
            newText = "Now that's what I call a " + animalName + "!";

        ObjectiveLimbs.text = newText;
    }

    public void updateLimbTypeText(int rightLimbs, int actualLimbs)
    {
        string newText;

        newText = "There's " + rightLimbs + " out of " + rightLimbs + " limbs.";
        ObjectiveLimbTypes.text = newText;
    }

    public void updateHeadText(bool hasHead, bool hasRightHead)
    {
        string newText;

        newText = "Has a head? " + (hasHead ? "Yes" : "No") + ". Is it right? " + (hasRightHead ? "Yes" : "No") + ".";
        ObjectiveHead.text = newText;
    }
}
