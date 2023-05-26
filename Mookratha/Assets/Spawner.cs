using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject food;

    private void Update()
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-10, 11), 5, Random.Range(-10, 11));
        Instantiate(food, randomSpawnPosition, Quaternion.identity);
    }
}
