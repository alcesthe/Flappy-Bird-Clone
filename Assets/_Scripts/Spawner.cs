using System;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
	[SerializeField] GameObject obstaclePrefab;
	[SerializeField] float spawnRate = 2;
	[SerializeField] float upperRangeY = 3;
	[SerializeField] float lowerRangeY = -2;
	[SerializeField] float spawnDelay = 0;
	void Start()
	{
		InvokeRepeating("SpawnObstacles", spawnDelay, spawnRate);
	}

    private void SpawnObstacles()
    {
		if (GameManager.instace.state == GameManager.GameState.Playing)
		{
			Vector2 spawnPoint = new Vector2(transform.position.x, Random.Range(lowerRangeY, upperRangeY));
			Instantiate(obstaclePrefab, spawnPoint, transform.rotation);
		}
    }
}
