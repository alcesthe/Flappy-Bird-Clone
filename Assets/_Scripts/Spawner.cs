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

	[Header("Power Up")]
	[SerializeField] GameObject[] powerUpPrefab;
	[Range(0,1)]
	[SerializeField] float percentageOfPowerUp = 0.1f;
	void Start()
	{
		InvokeRepeating("SpawnObstacles", spawnDelay, spawnRate);
	}

    private void SpawnObstacles()
    {
		if (GameManager.instace.state == GameManager.GameState.Playing)
		{
			Vector2 spawnPoint = new Vector2(transform.position.x, Random.Range(lowerRangeY, upperRangeY));
			if (Random.value < percentageOfPowerUp && !GameManager.instace.isPowerUpActive) // 10%
            {
				Instantiate(powerUpPrefab[Random.Range(0, powerUpPrefab.Length)], spawnPoint, transform.rotation);
			}
            else
            {
				Instantiate(obstaclePrefab, spawnPoint, transform.rotation);
			}
		}
    }
}
