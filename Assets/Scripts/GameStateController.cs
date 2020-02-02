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
    }

    public void OnUpdateAnimal (Animal animal)
    {
        c_objectives.OnUpdateAnimal(animal);
        Debug.Log("Update animal");
    }

    public void OnRedeemAnimal()
    {
        c_objectives.OnRedeemAnimal();
    }

    public void UpdateAnimalState()
    {
        c_eventText.updateLimbAnimalText(c_objectives.rightAnimal, c_objectives.howManyLimbs, c_objectives.totalLimbs);
        c_eventText.updateLimbTypeText(c_objectives.howManyLimbsRightType, c_objectives.totalLimbs);
        c_eventText.updateHeadText(c_objectives.hasHead, c_objectives.hasRightHead);
    }

    public void addScore(int amount)
    {
        score += amount;
    }

    public void deductScore(int amount)
    {
        score -= amount;
    }

}
