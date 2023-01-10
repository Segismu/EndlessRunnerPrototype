using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;

    public float spawnRangeA = 30f;
    public float spawnRangeB = 35f;
    [SerializeField] float spawnDelay = 2;
    [SerializeField] float spawnInterval = 1.5f;
    Vector3 spawnPos = new Vector3(25, 0, 0);
    private PlayerController playerControllerScript;
    

    void Start()
    {
        InvokeRepeating("SpawnObstacle", spawnDelay, spawnInterval);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void SpawnObstacle()
    {
        int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(spawnRangeA, spawnRangeB), 0, 0);

        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefabs[obstacleIndex], spawnPos, obstaclePrefabs[obstacleIndex].transform.rotation);
        }
        
    }
}
