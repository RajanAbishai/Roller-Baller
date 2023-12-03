using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private Enemy enemyPrefab; //a type of the Enemy script, not the game object

    /* SetTarget function in Enemy script is used to set the target for the specific enemy. 
     
     * Instead of spawning a new game object and using get compnent and then, calling the set target, it can be done this way*/

    private Enemy spawnedEnemy;
    private Vector3 spawnPos;

    [SerializeField]
    private float minSpawnPos = -30f, maxSpawnPos = 30f;

    [SerializeField]
    private float minYPos = 1f, maxYPos=5f;

    private Transform playerTarget;

    [SerializeField]
    private float minSpawnTime = 3f, maxSpawnTime = 6f;

    private float spawnTimer;

    private void Awake()
    {
        playerTarget = GameObject.FindGameObjectWithTag(TagManager.PLAYER_TAG).transform;
        /* Only one reference. We need to get the reference to player once and we pass it to every enemy that we create instead of 
           creating a new enemy everytime and we call over the code in awake (line 22)*/

    }

    private void Update()
    {
        checkToSpawnEnemy();
        
    }


    void SpawnEnemy()
    {
        /*
        spawnPos = new Vector3(Random.Range(minSpawnPos, maxSpawnPos),
            Random.Range(minYPos, maxYPos),
            Random.Range(minSpawnPos, maxSpawnPos));
        
        */
        //The above code randomizes the location

         spawnPos = transform.position; 
         /* This makes it spawn at the location of the spawner. This can be used to place spawners at specific locations */


        spawnedEnemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        spawnedEnemy.setTarget(playerTarget);
    }

    void checkToSpawnEnemy()
    {
        

        if (Time.time > spawnTimer)
        {
            spawnTimer = Time.time + Random.Range(minSpawnTime, maxSpawnTime);
            SpawnEnemy();
        }
    }


}
