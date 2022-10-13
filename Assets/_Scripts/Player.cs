using System;
using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField] float verticalSpeed = 7;
    [SerializeField] float timeToGetDown = 0.25f;
    [SerializeField] float upperBounder = 4.5f;

    [SerializeField] AudioClip jumpSound;
    [SerializeField] AudioClip deadSound;

    private float timer;
    private Vector2 direction;

    private void Start()
    {
        direction = Vector2.down; // Init value going down
    }

    private void Update()
    {
        if (GameManager.instace.state == GameManager.GameState.Playing)
        {
            PlayerMovement();
        }
    }

    private void PlayerMovement()
    {
        if (transform.position.y >= upperBounder){transform.position = new Vector2(transform.position.x, upperBounder);} // Clamp pos

        transform.Translate(direction * Time.deltaTime * verticalSpeed);
        timer += Time.deltaTime;

        // Jump Input
        if (Input.GetMouseButtonDown(0))
        {
            AudioSystem.PlaySound(jumpSound);
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

    public void Dead()
    {
        /*StartCoroutine("PlayDeadTrigger");*/
        AudioSystem.PlaySound(deadSound);
        gameObject.SetActive(false);
    }

/*    IEnumerator PlayDeadTrigger()
    {
        transform.Translate(Vector2.up * Time.deltaTime * 10);
        yield return new WaitForSeconds(0.2f);
        transform.Translate(Vector2.down * Time.deltaTime * 20);
    }
*/
}
