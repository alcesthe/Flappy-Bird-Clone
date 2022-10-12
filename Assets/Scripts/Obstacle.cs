using System;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] float speed = 5;
    private GameObject player;

    private bool isAdded = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
 	{
        ScoreAdd();
        MovingObject();
    }

    private void ScoreAdd()
    {
        if (!isAdded && gameObject.transform.position.x < player.transform.position.x)
        {
            Debug.Log("Score Added");
            isAdded = true;
        }
    }

    private void MovingObject()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed);
    }
}