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

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnEnemy()
    {
        // Bottom left point of screen
        Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));

        // top right point of screen
        Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

        // instantiate enemy
        GameObject newEnemy = (GameObject)Instantiate (enemy);
        enemy.transform.position = new Vector2 (max.x, Random.Range (min.y, max.y));
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
