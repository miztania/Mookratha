using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject[] foodObject;

    private Vector3 randomSpawnPosition;

    [Header("Spawning")]
    public float timeDuringSpawning = 2.0f;
    public float timeSpawnPeriod = 10f;

    [Header("Randon Details")]
    public float randomRange = 3f;
    public float hightSpawn = 10f;



    private int  foodRandomNum;
    private void Start()
    {
    
        InvokeRepeating("CreateFood", timeDuringSpawning, timeSpawnPeriod);
    }


    private void Update()
    {
        randomSpawnPosition = new Vector3(Random.Range(-randomRange, randomRange), hightSpawn, Random.Range(-randomRange, randomRange));
        foodRandomNum = Random.Range(0, foodObject.Length);

    
    }

    private void CreateFood()
    {

        Instantiate(foodObject[foodRandomNum], randomSpawnPosition, Quaternion.Euler(new Vector3(-90, 0, 0)));
    }
        
}
