using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerObstacles : MonoBehaviour
{
    public GameObject prefabObstacles;
    private float spawnDelay = 2;
    private float spawnInterval = 4f;
    
    void Start()
    {
        InvokeRepeating("SpawnObstacles", spawnDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnObstacles()
    {
        Vector3 spawnLocation = new Vector3(-4.59898f, Random.Range(0.37f, 2f), Random.Range(29.72f, 20.6f));
        Instantiate(prefabObstacles, spawnLocation, Quaternion.identity);
    }
}
