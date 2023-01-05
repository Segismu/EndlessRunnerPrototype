using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] float spawnDelay = 2;
    [SerializeField] float spawnInterval = 1.5f;
    Vector3 spawnPos = new Vector3(25, 0, 0);
    

    void Start()
    {
        InvokeRepeating("SpawnObstacle", spawnDelay, spawnInterval);
    }

    void SpawnObstacle()
    {
        Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);

    }
}
