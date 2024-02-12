using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSpawner : MonoBehaviour
{
    public GameObject mousePrefab;
    public float spawnInterval = 3f;
    private float timer = 0f;

    private float Door1X = -14.7f;
    private float Door2X = 5.39f;


    public float minY = -6.37f;
    private float minZ = -3.41773415f;
    private float maxZ = 7.08226585f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnInterval)
        {
            SpawnMouse();
            timer = 0;
        }
    }

    void SpawnMouse()
    {
        float randomX = Random.Range(Door1X, Door2X);
        float randomZ = Random.Range(minZ, maxZ);
        Vector3 spawnPosition = new Vector3(randomX, minY, randomZ);
        Instantiate(mousePrefab, spawnPosition, Quaternion.identity);
    }
}