using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : MonoBehaviour
{
    protected ObjectiveController c_objectives;
    protected EventTextController c_eventText;
    protected ScoreController c_score;

    private void Start()
    {
        c_objectives = GetComponent<ObjectiveController>();
        c_eventText = GetComponent<EventTextController>();
        c_score = GetComponent<ScoreController>();
    }

    public void OnNewAnimal (Animal animal)
    {
        c_objectives.OnNewAnimal(animal);
        c_eventText.SpawnAnimalText(animal.animal);
    }

    public void OnRedeemAnimal()
    {
        c_objectives.OnRedeemAnimal();
    }
}
