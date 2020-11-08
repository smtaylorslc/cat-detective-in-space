using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject enemy;
    float maxSpawnRateInSeconds = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnEnemy", maxSpawnRateInSeconds);
        InvokeRepeating("IncreaseSpawnRate", 0f, 30f);
    }
    float nextRandom(float minVal, float maxVal){
        float u, v, S;

        do
        {
            u = 2.0f * Random.value - 1.0f;
            v = 2.0f * Random.value - 1.0f;
            S = u * u + v * v;
        }
        while (S >= 1.0f);

        float std = u * Mathf.Sqrt(-2.0f * Mathf.Log(S) / S);
 
        // Normal Distribution centered between the min and max value
        // and clamped following the "three-sigma rule"
        float mean = (minVal + maxVal) / 2.0f;
        float sigma = (maxVal - mean) / 3.0f;
        return Mathf.Clamp(std * sigma + mean, minVal, maxVal);
    }
    void SpawnEnemy()
    {
        // Bottom left point of screen
        Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));

        // top right point of screen
        Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

        // instantiate enemy
        GameObject newEnemy = (GameObject)Instantiate (enemy);
        enemy.transform.position = new Vector2 (max.x, nextRandom(min.y, max.y));
        ScheduleNextEnemySpawn();
    }
    void ScheduleNextEnemySpawn()
    {
        float spawnInNSeconds;
        if(maxSpawnRateInSeconds > 1f)
        {
            // pick a number between 1 and maxspawnrateinseconds
            spawnInNSeconds = Random.Range(1f, maxSpawnRateInSeconds);
        } else
        {
            spawnInNSeconds = 1f;
        }

        Invoke ("SpawnEnemy", spawnInNSeconds);
    }

    void IncreaseSpawnRate()
    {
        if(maxSpawnRateInSeconds > 1f) {
            maxSpawnRateInSeconds--;
        }
        if(maxSpawnRateInSeconds == 1f){
            CancelInvoke("IncreaseSpawnRate");
        };
    }
}
