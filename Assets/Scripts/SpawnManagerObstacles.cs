using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerObstacles : MonoBehaviour
{
    public GameObject prefabObstacles;
    private float spawnDelay = 2;
    private float spawnInterval = 0.5f;
    
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
        Vector3 spawnLocation = new Vector3(-10.41534f, Random.Range(3.34f, 6.58f), Random.Range(47.29936f, 83.63f));
        Instantiate(prefabObstacles, spawnLocation, Quaternion.identity);
    }
}
