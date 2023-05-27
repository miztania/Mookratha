using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] foodObject;

    private Vector3 randomSpawnPosition;
    public float spawndTime = 5f;
    public float startTime;
    private int  foodRandomNum;
    private void Start()
    {
        startTime = Time.time;
        InvokeRepeating("CreateFood", 1.0f, 10f);
    }


    private void Update()
    {
        randomSpawnPosition = new Vector3(Random.Range(-3, 3), 10, Random.Range(-3, 3));
        foodRandomNum = Random.Range(0, foodObject.Length);

    
    }

    private void CreateFood()
    {

        Instantiate(foodObject[foodRandomNum], randomSpawnPosition, Quaternion.Euler(new Vector3(-90, 0, 0)));
    }
        
}
