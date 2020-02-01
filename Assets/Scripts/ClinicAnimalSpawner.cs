using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClinicAnimalSpawner : MonoBehaviour
{
    public GameObject animalPrefab;
    public Transform animalSpawnPoint;
    public Rigidbody operatingTable;
    Animal currentAnimal;

    float startHeight = 0f;
    public float endHeight = 10f;
    public float tableSpeed = 5f;
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
            if (currentAnimal != null)
                Destroy(currentAnimal.gameObject);
            spawningAnimal = true;
            StartCoroutine(SpawnAnimalSequence());
        }
    }

    IEnumerator SpawnAnimalSequence() {
        yield return null;
        while (operatingTable.position.y > endHeight) {
            operatingTable.MovePosition(operatingTable.position - Vector3.up * Time.deltaTime * tableSpeed);
            yield return null;
        }
        currentAnimal = Instantiate(animalPrefab, animalSpawnPoint.position, animalSpawnPoint.rotation).GetComponent<Animal>();
        currentAnimal.animal = new string[] { "cat", "dog", "crow" }[Random.Range(0, 3)];
        currentAnimal.transform.parent = animalSpawnPoint.transform;
        while (operatingTable.position.y < startHeight) {
            operatingTable.MovePosition(operatingTable.position + Vector3.up * Time.deltaTime * tableSpeed);
            yield return null;
        }
        operatingTable.MovePosition(new Vector3(operatingTable.position.x, startHeight, operatingTable.position.z));
        spawningAnimal = false;
    }

}
