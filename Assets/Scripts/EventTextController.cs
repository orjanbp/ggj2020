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
    public TextMeshProUGUI ScoreTracker;

    private void Start()
    {
        ObjectiveLimbs.text = "";
        ObjectiveLimbTypes.text = "";
        ObjectiveHead.text = "";
        ScoreTracker.text = "";
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

        newText = "What do you even call this thing?!";

        if (rightLimbs > allLimbs / 2)
            newText = "It's mostly a " + animalName + ", at least.";

        if (rightLimbs == allLimbs)
            newText = "Now that's what I call a " + animalName + "!";

        ObjectiveLimbs.text = newText;
    }

    public void updateLimbTypeText(int rightLimbs, int actualLimbs)
    {
        string newText;

        newText = "It's barely even an animal!";

        if (rightLimbs > 2)
            newText = "Is there anything on there as it should be?";

        if (rightLimbs > actualLimbs / 2)
            newText = "It's almost all where it should be at.";

        if (rightLimbs == actualLimbs)
            newText = "Right parts in the right place.";


        ObjectiveLimbTypes.text = newText;
    }

    public void updateHeadText(bool hasHead, bool hasRightHead)
    {
        string newText;

        newText = "";

        if (!hasHead)
            newText = "Shouldn't there be a head on there?";

        if (hasHead && !hasRightHead)
            newText = "At least it's some kind of a head.";

        if (hasHead && hasRightHead)
            newText = "That's the right head. Great!";

        ObjectiveHead.text = newText;
    }

    public void UpdateScoreText (int score)
    {
        Debug.Log("Updating score text!!!");
        ScoreTracker.text = "SCORE: " + score;

        if (score < 0)
        {
            ScoreTracker.color = new Color(255, 146, 146);
        }
        else if (score > 500)
        {
            ScoreTracker.color = new Color(162, 255, 146);
        }
        else
        {
            ScoreTracker.color = new Color(255, 255, 255);
        }
    }
}
