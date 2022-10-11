using System;
using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField] float verticalSpeed = 7;
    [SerializeField] float timeToGetDown = 0.25f;

    private float timer;
    private Vector2 direction;

    private void Start()
    {
        direction = Vector2.down; // Init value going down
    }

    private void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        transform.Translate(direction * Time.deltaTime * verticalSpeed);
        timer += Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            timer = 0;
        }

        if (timer > timeToGetDown)
        {
            direction = Vector2.down;
        }
        else
        {
            direction = Vector2.up;
        }
    }

}
