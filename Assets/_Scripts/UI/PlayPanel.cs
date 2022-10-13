using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayPanel : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Button powerUpButton;
    [SerializeField] GameObject powerUpHolder;
    [SerializeField] Sprite explosion;
    [SerializeField] Sprite strength;
    [SerializeField] Sprite slow;

    private GameObject player;
    private Player playerScript;
    private Image powerUpImage;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<Player>();
        powerUpImage = powerUpHolder.GetComponent<Image>();

        powerUpButton.onClick.AddListener(delegate
        {
            playerScript.PlayPowerUp();
            GameManager.instace.currentPowerUp = GameManager.PowerUp.None;
        });
    }

    private void Update()
    {
        scoreText.text = GameManager.instace.score.ToString();
        UpdatePowerUpImage();
    }

    private void UpdatePowerUpImage()
    {
        switch (GameManager.instace.currentPowerUp)
        {
            case (GameManager.PowerUp.None):
                powerUpHolder.SetActive(false);
                break;
            case (GameManager.PowerUp.Explosion):
                powerUpHolder.SetActive(true);
                powerUpImage.sprite = explosion;
                break;
            case (GameManager.PowerUp.Strength):
                powerUpHolder.SetActive(true);
                powerUpImage.sprite = strength;
                break;
            case (GameManager.PowerUp.Slow):
                powerUpHolder.SetActive(true);
                powerUpImage.sprite = slow;
                break;
        }
    }
}
