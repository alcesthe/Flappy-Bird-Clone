using System;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] float speed = 5;
    [SerializeField] private float rangeToDestroy = -10f;
    [SerializeField] AudioClip scoreSound;
    private GameObject player;
    
    private bool isAdded = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
 	{
        ScoreAdd();
        if (GameManager.instace.state == GameManager.GameState.Playing)
        {
            MovingObject();
        }
        DestroyWhenOutRange();
    }

    private void DestroyWhenOutRange()
    {
        if (transform.position.x < rangeToDestroy)
        {
            Destroy(gameObject);
        }
    }

    private void ScoreAdd()
    {
        if (!isAdded && gameObject.transform.position.x < player.transform.position.x)
        {
            GameManager.instace.score += 1;
            AudioSystem.PlaySound(scoreSound);
            isAdded = true;
        }
    }

    private void MovingObject()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed);
    }
}
