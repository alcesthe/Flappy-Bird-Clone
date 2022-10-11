using System;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
	[SerializeField] GameObject obstaclePrefab;
	[SerializeField] float spawnRate = 2;
	[SerializeField] float rangeY = 3;
	[SerializeField] float spawnDelay = 0;
	void Start()
	{
		InvokeRepeating("SpawnObstacles", spawnDelay, spawnRate);
	}

    private void SpawnObstacles()
    {
		Vector2 spawnPoint = new Vector2(transform.position.x, Random.Range(-rangeY, rangeY));
		Instantiate(obstaclePrefab, spawnPoint, transform.rotation);
    }
}
