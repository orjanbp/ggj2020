using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClinicAnimalSpawner : MonoBehaviour
{
    public ObjectiveController objectiveController;
    public GameObject[] allAnimalPrefabs;
    public Transform animalSpawnPoint;
    public Rigidbody operatingTable;
    Animal currentAnimal;

    float startHeight = 0f;
    public float endHeight = 10f;
    public float tableSpeed = 5f;
    public AnimationCurve redeemAnimalCurve;
    bool spawningAnimal;

    private void Start() {
        startHeight = operatingTable.position.y;
        SpawnNewAnimal();
    }

    private void Update() {
        //if (currentAnimal == null && !spawningAnimal) {

            
        //}
        if (Input.GetKeyDown(KeyCode.Space)) {
            SpawnNewAnimal();
        }

    }

    public void SpawnNewAnimal() {
        if (!spawningAnimal) {
            spawningAnimal = true;
            StartCoroutine(SpawnAnimalSequence());
        }
    }

    IEnumerator SpawnAnimalSequence() {
        if (currentAnimal != null) {
            yield return StartCoroutine(RedeemAnimalRoutine());
        }
        yield return null;
        while (operatingTable.position.y > endHeight) {
            operatingTable.MovePosition(operatingTable.position - Vector3.up * Time.deltaTime * tableSpeed);
            yield return null;
        }
        currentAnimal = Instantiate(allAnimalPrefabs[Random.Range(0, allAnimalPrefabs.Length)], animalSpawnPoint.position, animalSpawnPoint.rotation).GetComponent<Animal>();
        //currentAnimal.animal = new string[] { "cat", "dog", "crow" }[Random.Range(0, 3)];
        currentAnimal.transform.parent = animalSpawnPoint.transform;
        while (operatingTable.position.y < startHeight) {
            operatingTable.MovePosition(operatingTable.position + Vector3.up * Time.deltaTime * tableSpeed);
            yield return null;
        }
        operatingTable.MovePosition(new Vector3(operatingTable.position.x, startHeight, operatingTable.position.z));
        spawningAnimal = false;
        objectiveController.OnNewAnimal(currentAnimal);
    }

    IEnumerator RedeemAnimalRoutine() {
        Screenshotter.ScreenshotAndStore();
        float startingY = operatingTable.position.y;
        bool animalAscending = false;
        float timer = 0f;
        objectiveController.OnRedeemAnimal();
        while (timer <= 1f) {
            float curveAdd = redeemAnimalCurve.Evaluate(timer);
            operatingTable.MovePosition(new Vector3(operatingTable.position.x, startingY + curveAdd, operatingTable.position.z));
            timer += Time.deltaTime;
            if (timer > 0.15f && !animalAscending) {
                animalAscending = true;
                StartCoroutine(OldAnimalAscender(currentAnimal));
            }
                
            yield return null;
        }
    }

    IEnumerator OldAnimalAscender(Animal animalToAscend) {
        currentAnimal.transform.parent = null;
        while (currentAnimal.transform.position.y < 15f) {
            currentAnimal.transform.position += Vector3.up * Time.deltaTime * 9f;
            yield return null;
        }
        Destroy(currentAnimal.gameObject);
    }

}
