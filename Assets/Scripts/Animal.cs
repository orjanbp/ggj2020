using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public AttachPoint[] attachPoints;
    public LimbManager m_LimbManager;
    public GameStateController c_GameState;

    public string animal;
    public AnimalType animalType;
    public bool debugKeepAllLimbs;
    
    // Start is called before the first frame update
    void Start()
    {
        c_GameState = GameObject.Find("GameStateManager").GetComponent<GameStateController>();

        int firstMissingLimb = Random.Range(0, attachPoints.Length);
        for (int i = 0; i < attachPoints.Length; i++)
        {
            attachPoints[i].SetAnimalRef(this);
            if (!debugKeepAllLimbs && (i == firstMissingLimb || Random.value < 0.25f))
                continue;
            var limbPrefab = m_LimbManager.FetchLimb(animalType, attachPoints[i].limbType_);
            var attPos = attachPoints[i].transform.position;
            var attRot = attachPoints[i].transform.rotation;

            var newLimb = Instantiate(limbPrefab, attPos, attRot);
            attachPoints[i].AttachLimb(newLimb);
            //Debug.Log("ADDING NEW LIMB: " + attPoint + newLimb);
            //Debug.Log(newLimb.anchorPointOffset);|
        }
    }

    public void OnChangeLimbs()
    {
        c_GameState.OnUpdateAnimal(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum AnimalType {
    Cat,
    Dog,
    Crow,
    Cow,
    Other,
    StaticHook
}