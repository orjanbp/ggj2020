using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EventTextController : MonoBehaviour
{
    public TextMeshProUGUI cornerText;
    public TextMeshProUGUI animalText;

    public RectTransform spawnCorner;
    public RectTransform spawnBottom;

    public void SpawnAnimalText (string animalName)
    {
        Component flyingText = Instantiate(animalText, spawnBottom.position, spawnBottom.rotation, spawnBottom.parent);
        flyingText.GetComponent<TextMeshProUGUI>().text = "Holy crap, it's a " + animalName + "!";
    }

    public void SpawnCornerText(string textInput)
    {
        Component flyingText = Instantiate(cornerText, spawnCorner.position, spawnCorner.rotation, spawnCorner.parent);
        flyingText.GetComponent<TextMeshProUGUI>().text = textInput;
    }
}
