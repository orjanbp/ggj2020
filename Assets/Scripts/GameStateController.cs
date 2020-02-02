using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : MonoBehaviour
{
    protected ObjectiveController c_objectives;
    protected EventTextController c_eventText;

    protected int score = 0;

    private void Start()
    {
        c_objectives = GetComponent<ObjectiveController>();
        c_eventText = GetComponent<EventTextController>();
    }

    public void OnNewAnimal (Animal animal)
    {
        c_objectives.OnNewAnimal(animal);
        c_eventText.SpawnAnimalText(animal.animal);
        c_eventText.UpdateScoreText(score);
    }

    public void OnUpdateAnimal (Animal animal)
    {
        c_objectives.OnUpdateAnimal(animal);
        Debug.Log("Update animal");
    }

    public void OnRedeemAnimal()
    {
        c_objectives.OnRedeemAnimal();

        var sumScore = 0;

        int limbPlacement = -50 + ((c_objectives.howManyLimbsRightType * 20));
        Debug.Log("Score from limbs in right place:" + limbPlacement);

        int limbAnimal = -50 + ((c_objectives.howManyLimbsRightAnimal * 20));
        Debug.Log("Score from limbs of right animal:" + limbAnimal);

        int limbCount = -50 + ((c_objectives.howManyLimbs  * 20));
        Debug.Log("Score from number of limbs:" + limbCount);

        sumScore += limbPlacement + limbAnimal + limbCount;

        if (c_objectives.howManyLimbsRightType == c_objectives.totalLimbs)
            sumScore += 200;

        if (c_objectives.howManyLimbsRightAnimal == c_objectives.totalLimbs)
            sumScore += 200;

        if (c_objectives.howManyLimbs == c_objectives.totalLimbs)
            sumScore += 200;

        Debug.Log("Final score: " + sumScore);
        updateScore(sumScore);
    }

    public void UpdateAnimalState()
    {
        c_eventText.updateLimbAnimalText(c_objectives.rightAnimal, c_objectives.howManyLimbs, c_objectives.totalLimbs);
        c_eventText.updateLimbTypeText(c_objectives.howManyLimbsRightType, c_objectives.totalLimbs);
        c_eventText.updateHeadText(c_objectives.hasHead, c_objectives.hasRightHead);
    }

    public void updateScore(int amount)
    {
        score += amount;
        c_eventText.UpdateScoreText(score);
    }
}
