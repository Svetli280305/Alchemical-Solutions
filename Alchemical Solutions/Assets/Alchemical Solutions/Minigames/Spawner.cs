using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //Create a public array of objects to spawn, we will fill this up using the unity editor
    public GameObject[] objectsToSpawn;

    float timeToNextSpawn;   //Tracks how long we should wait before spawning a new object
    float timeSinceLastSpawn = 0.0f;  //Tracks the time since we last spawned something

    public float minSpawnTime = 0.5f;  //Minimum amount of time between spawning objects
    public float maxSpawnTime = 3.0f;  //Maximum amount of time between spawning objects

    // Start is called before the first frame update
    void Start()
    {
        //Random.range returns a random float between two values
        timeToNextSpawn = Random.Range(minSpawnTime, minSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn = timeSinceLastSpawn + Time.deltaTime;

        if (timeSinceLastSpawn > timeToNextSpawn)
        {
           int selection = Random.Range(0, objectsToSpawn.Length);

            Instantiate(objectsToSpawn[selection], transform.position, Quaternion.identity);

            timeToNextSpawn = Random.Range(minSpawnTime, maxSpawnTime);
            timeSinceLastSpawn = 0.0f;
        }
    }
}
