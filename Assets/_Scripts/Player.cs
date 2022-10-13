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
    private static event Action powerUpAction;
    private static event Action powerUpActionDelay;
    private float delayActionTime = 0;

    public bool isInvicible = false;
    public AudioClip powerUpSound;

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
        AudioSystem.PlaySound(deadSound);
        transform.position = new Vector2(-10, 0);
        if (powerUpActionDelay != null)
        {
            powerUpActionDelay?.Invoke();
        }
    }

    // Action
    public void PlayPowerUp()
    {
        if (powerUpSound != null)
        {
            AudioSystem.PlaySound(powerUpSound);
            powerUpSound = null;
        }

        powerUpAction?.Invoke();
        if (powerUpActionDelay != null)
        {
            StartCoroutine(PlayerPowerUpDelay());
        }
        else
        {
            ClearPowerUpAction();
        }
    }

    IEnumerator PlayerPowerUpDelay()
    {
        GameManager.instace.isPowerUpActive = true;
        yield return new WaitForSeconds(delayActionTime);
        powerUpActionDelay?.Invoke();
        delayActionTime = 0; // Reset;
        GameManager.instace.isPowerUpActive = false;
        ClearPowerUpAction();
    }
    
    public static void ClearPowerUpAction()
    {
        powerUpAction = null;
        powerUpActionDelay = null;
    }

    public void SetPowerUpAction(Action action) => powerUpAction = action;
    public void SetPowerUpDelayAction(Action action, float delayTime)
    {
        powerUpActionDelay = action;
        delayActionTime = delayTime;
    }

    public bool CheckPowerUpIsAvailable()
    {
        if (powerUpAction != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
