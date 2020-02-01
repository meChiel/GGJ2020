using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawner : MonoBehaviour
{
    public float birdsPerSecond;
    public GameObject birdPrefab;
    public float minDistance;
    public float maxDistance;
    public float minSpawnHeight;
    public float maxSpawnHeight;

    float previousSpawnTime = 0;
    float timePerBird;

    void Start()
    {
        timePerBird = 1 / birdsPerSecond;
    }

    void Update()
    {
        if (Time.time > previousSpawnTime + timePerBird)
        {
            spawnBird();
            previousSpawnTime = Time.time;
        }
    }

    void spawnBird()
    {
        float angle = Random.Range(0, 2 * Mathf.PI);
        float distance = Random.Range(minDistance, maxDistance);
        float x = distance * Mathf.Cos(angle);
        float z = distance * Mathf.Sin(angle);

        float spawnHeight = Random.Range(minDistance, maxDistance);
        Vector3 birdPos = new Vector3(x, spawnHeight, z);

        Instantiate(birdPrefab, birdPos, Quaternion.identity, this.transform);
    }
}
