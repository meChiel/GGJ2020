using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrabSpawner : MonoBehaviour
{
    public float crabsPerSecond;
    public GameObject crabPrefab;
    public float distance;
    public float spawnHeight;
    public Slider crabSlider;
    public float minDistance;
    public float maxDistance;


    float previousSpawnTime = 0;
    float timePerCrab;

    void Start()
    {
        timePerCrab = 1 / crabsPerSecond;
    }

    void Update()
    {
        //Debug.Log("crabsPerSecond: " + crabsPerSecond + " slider value: " + crabSlider.value);
        crabsPerSecond = crabSlider.value;
        timePerCrab = 1 / crabsPerSecond;
        //crabSlider.GetComponent<Text>().text = "Crab slider value: " + crabsPerSecond;
        if (Time.time > previousSpawnTime + timePerCrab)
        {
            spawnCrab();
            previousSpawnTime = Time.time;
        }
    }

    void spawnCrab()
    {
        float angle = Random.Range(0, 2 * Mathf.PI);
        float distance = Random.Range(minDistance, maxDistance);
        float x = distance * Mathf.Cos(angle);
        float z = distance * Mathf.Sin(angle);

        Vector3 crabPos = new Vector3(x, spawnHeight, z);

        Instantiate(crabPrefab, crabPos, Quaternion.identity, this.transform);
    }

    public void setSpawnSpeed()
    {
        crabsPerSecond = crabSlider.value;
        crabSlider.GetComponent<Text>().text = "Crab slider value: " + crabsPerSecond;
        
    }

}
